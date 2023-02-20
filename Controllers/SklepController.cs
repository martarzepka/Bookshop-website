using Ksiegarnia.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Ksiegarnia.Models;
using System.Linq;

namespace Ksiegarnia.Controllers
{
    //[Route("buka.pl")]
    public class SklepController : Controller
    {
        private readonly MyDbContext _context;
        
        public SklepController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Ksiazki
        //[HttpGet("katalog")]
        public async Task<IActionResult> Katalog()
        {
            ViewData["Ceny"] = _context.Ceny.ToList();
            return View(await _context.Ksiazki.ToListAsync());
        }

        // GET: Ksiazki/Details/5
        public async Task<IActionResult> Szczegoly(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ksiazka = await _context.Ksiazki
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewData["Autorzy"] = _context.KsiazkaAutor
               .Where(c => c.KsiazkaId == id)
               .Join(_context.Autorzy, cs => cs.AutorId, c => c.Id, (cs, c) => c)
               .ToList();
            ViewData["Kategorie"] = _context.KsiazkaKategoria
               .Where(c => c.KsiazkaId == id)
               .Join(_context.Kategorie, cs => cs.KategoriaId, c => c.Id, (cs, c) => c)
               .ToList();
            Cena cena = _context.Ceny
               .Where(c => c.KsiazkaId == id)
               .FirstOrDefault(c => c.DataOd <= DateTime.Today && (c.DataDo == DateTime.MinValue || c.DataDo >= DateTime.Today));
            ViewData["Cena"] = String.Format("{0:N2}", cena.Wartosc);
            if (ksiazka == null)
            {
                return NotFound();
            }

            return View(ksiazka);
        }


        public Dictionary<int, PozycjaWKoszyku> PobierzKoszyk()
        {
            Dictionary<int, PozycjaWKoszyku> koszyk;
            string c;
            Request.Cookies.TryGetValue("koszyk", out c);
            if (c != null)
            {
                koszyk = JsonConvert.DeserializeObject<Dictionary<int, PozycjaWKoszyku>>(Request.Cookies["koszyk"]);
            }
            else
            {
                koszyk = new Dictionary<int, PozycjaWKoszyku>();
            }
            return koszyk;
        }
        
        public void UstawKoszyk(Dictionary<int, PozycjaWKoszyku> koszyk)
        {
            string c = JsonConvert.SerializeObject(koszyk);
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append("koszyk", c, options);
        }

        private bool PozycjaWKoszykuExists(int id)
        {
            Dictionary<int, PozycjaWKoszyku> koszyk = PobierzKoszyk();
            if (koszyk == null) return false;
            return koszyk.ContainsKey(id);
        }

        public async Task<IActionResult> Koszyk()
        {
            Dictionary<int, PozycjaWKoszyku> koszyk = PobierzKoszyk();
            ViewBag.Suma = String.Format("{0:N2}", PoliczSume());
            List<PozycjaWKoszyku> koszykList = new List<PozycjaWKoszyku>();

            ViewData["Ceny"] = _context.Ceny.ToList();

            var klucze = koszyk.Keys.ToList();
            var ksiazki = await _context.Ksiazki.Include(a => a.KsiazkaKategoria).Where(a => klucze.Contains(a.Id)).ToListAsync();

            foreach (var ksiazka in ksiazki)
            {
                koszykList.Add(new PozycjaWKoszyku
                {
                    KsiazkaId = ksiazka.Id,
                    Ksiazka = ksiazka,
                    Liczba = koszyk[ksiazka.Id].Liczba
                });
            }
            TempData["Powiadomienie"] = null;

            return View(koszykList);
        }

        public float PoliczSume()
        {
            Dictionary<int, PozycjaWKoszyku> koszyk = PobierzKoszyk();
            float suma = 0.0F;
            if (koszyk == null)
            {
                return suma;
            }

            var ksiazki = _context.Ksiazki.Include(s => s.Cena).ToList();
            foreach (KeyValuePair<int, PozycjaWKoszyku> item in koszyk)
            {
                if (ksiazki.Where(a => a.Id == item.Value.KsiazkaId).Count() > 0)
                {
                    Cena cena = _context.Ceny
                               .Where(c => c.KsiazkaId == item.Value.KsiazkaId)
                               .FirstOrDefault(c => c.DataOd <= DateTime.Today && (c.DataDo == DateTime.MinValue || c.DataDo >= DateTime.Today));
                    suma += cena.Wartosc * item.Value.Liczba;
                }
            }
            return suma;
        }

        public IActionResult Dodaj(int id)
        {
            Dictionary<int, PozycjaWKoszyku> koszyk = PobierzKoszyk();
            if (PozycjaWKoszykuExists(id))
            {
                koszyk[id].Liczba++;
            }
            else
            {
                PozycjaWKoszyku PozycjaWKoszyku = new PozycjaWKoszyku
                {
                    KsiazkaId = id,
                    Ksiazka = _context.Ksiazki.SingleOrDefault(
                        a => a.Id == id),
                    Liczba = 1
                };
                koszyk.Add(id, PozycjaWKoszyku);
            }
            
            UstawKoszyk(koszyk);
            TempData["Powiadomienie"] = "Produkt został dodany do koszyka";
            return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }

        public IActionResult Odejmij(int id)
        {
            Dictionary<int, PozycjaWKoszyku> koszyk = PobierzKoszyk();

            if (PozycjaWKoszykuExists(id))
            {
                if (koszyk[id].Liczba >= 1)
                    koszyk[id].Liczba--;
                
            }

            UstawKoszyk(koszyk);
            return RedirectToAction("Koszyk");
        }

        public IActionResult Usun(int id)
        {
            Dictionary<int, PozycjaWKoszyku> koszyk = PobierzKoszyk();

            if (PozycjaWKoszykuExists(id))
            {
                koszyk.Remove(id);
                UstawKoszyk(koszyk);
            }

            return RedirectToAction("Koszyk");
        }
    }
}
