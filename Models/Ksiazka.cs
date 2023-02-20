using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace Ksiegarnia.Models
{
    public class Ksiazka
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = " Zbyt dlugi tytul")]
        public string Tytul { get; set; }

        [Required]
        [DisplayName("Dostępnych")]
        public int Dostepnosc { get; set; }

        [Required]
        public bool CzyWOfercie { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = " Zbyt dlugi opis")]
        public string Opis { get; set; }

        public ICollection<Cena> Cena { get; set; }

        [DisplayName("Kategorie")]
        public ICollection<KsiazkaKategoria> KsiazkaKategoria { get; set; }

        [DisplayName("Autorzy")]
        public ICollection<KsiazkaAutor> KsiazkaAutor { get; set; }

        [NotMapped]
        public IFormFile Okladka { get; set; }

        [DisplayName("Okładka")]
        public string Sciezka { get; set; }

        public Ksiazka()
        {
        }
    }
}
