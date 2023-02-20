using Ksiegarnia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Ksiegarnia.Data
{
    public static class MyBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Kategoria>().HasData(
               new Kategoria()
               {
                   Id = 1,
                   Nazwa = "Fantastyka"
               },
               new Kategoria()
               {
                   Id = 2,
                   Nazwa = "Kryminał"
               },
               new Kategoria()
               {
                   Id = 3,
                   Nazwa = "Science Fiction"
               },
               new Kategoria()
               {
                   Id = 4,
                   Nazwa = "Thriller"
               }

               );

            modelBuilder.Entity<KsiazkaKategoria>().HasData(
               new KsiazkaKategoria()
               {
                   KsiazkaId = 1,
                   KategoriaId = 2
               },
               new KsiazkaKategoria()
               {
                   KsiazkaId = 1,
                   KategoriaId = 4
               },
               new KsiazkaKategoria()
               {
                   KsiazkaId = 2,
                   KategoriaId = 2
               },
               new KsiazkaKategoria()
               {
                   KsiazkaId = 2,
                   KategoriaId = 4
               },
               new KsiazkaKategoria()
               {
                   KsiazkaId = 3,
                   KategoriaId = 2
               },
               new KsiazkaKategoria()
               {
                   KsiazkaId = 3,
                   KategoriaId = 4
               },
               new KsiazkaKategoria()
               {
                   KsiazkaId = 4,
                   KategoriaId = 3
               },
               new KsiazkaKategoria()
               {
                   KsiazkaId = 5,
                   KategoriaId = 1
               },
               new KsiazkaKategoria()
               {
                   KsiazkaId = 5,
                   KategoriaId = 3
               },
               new KsiazkaKategoria()
               {
                   KsiazkaId = 6,
                   KategoriaId = 1
               },
               new KsiazkaKategoria()
               {
                   KsiazkaId = 6,
                   KategoriaId = 3
               }
               );

            modelBuilder.Entity<Autor>().HasData(
               new Autor()
               {
                   Id = 1,
                   Imie = "Jenny",
                   Nazwisko = "Blackhurst"
               },
               new Autor()
               {
                   Id = 2,
                   Imie = "Paula",
                   Nazwisko = "Hawkings"
               },
               new Autor()
               {
                   Id = 3,
                   Imie = "Andy",
                   Nazwisko = "Weir"
               },
               new Autor()
               {
                   Id = 4,
                   Nazwisko = "Daveniss"
               },
               new Autor()
               {
                   Id = 5,
                   Imie = "Diego",
                   Nazwisko = "Agrimbau"
               },
               new Autor()
               {
                   Id = 6,
                   Imie = "Lucas",
                   Nazwisko = "Varela"
               }

               );

            modelBuilder.Entity<KsiazkaAutor>().HasData(
               new KsiazkaAutor()
               {
                   KsiazkaId = 1,
                   AutorId = 1
               },
               new KsiazkaAutor()
               {
                   KsiazkaId = 2,
                   AutorId = 2
               },
               new KsiazkaAutor()
               {
                   KsiazkaId = 3,
                   AutorId = 1
               },
               new KsiazkaAutor()
               {
                   KsiazkaId = 4,
                   AutorId = 3
               },
               new KsiazkaAutor()
               {
                   KsiazkaId = 5,
                   AutorId = 4
               },
               new KsiazkaAutor()
               {
                   KsiazkaId = 6,
                   AutorId = 5
               },
               new KsiazkaAutor()
               {
                   KsiazkaId = 6,
                   AutorId = 6
               }

               );

            modelBuilder.Entity<Cena>().HasData(
               new Cena()
               {
                   Id = 1,
                   DataOd = new DateTime(2023,1,2),
                   Wartosc = 6.99F,
                   CzyPromocja = false,
                   KsiazkaId = 1
               },
               new Cena()
               {
                   Id = 2,
                   DataOd = new DateTime(2022, 10, 12),
                   Wartosc = 12.42F,
                   CzyPromocja = false,
                   KsiazkaId = 2
               },
               new Cena()
               {
                   Id = 3,
                   DataOd = new DateTime(2023, 1, 1),
                   DataDo = new DateTime(2024, 1, 1),
                   Wartosc = 27.95F,
                   CzyPromocja = false,
                   KsiazkaId = 3
               },
               new Cena()
               {
                   Id = 4,
                   DataOd = new DateTime(2021, 9, 5),
                   Wartosc = 26.23F,
                   CzyPromocja = false,
                   KsiazkaId = 4
               },
               new Cena()
               {
                   Id = 5,
                   DataOd = new DateTime(2022, 2, 14),
                   Wartosc = 15.60F,
                   CzyPromocja = false,
                   KsiazkaId = 5
               },
               new Cena()
               {
                   Id = 6,
                   DataOd = new DateTime(2022, 8, 21),
                   Wartosc = 60.97F,
                   CzyPromocja = false,
                   KsiazkaId = 6
               },
               new Cena()
               {
                   Id = 7,
                   DataOd = new DateTime(2022, 11, 23),
                   DataDo = new DateTime(2023, 1, 1),
                   Wartosc = 6.99F,
                   CzyPromocja = true,
                   KsiazkaId = 1
               }

               );

            modelBuilder.Entity<Ksiazka>().HasData(
                    new Ksiazka()
                    {
                        Id = 1,
                        Tytul = "Noc, kiedy umarła",
                        Dostepnosc = 15,
                        CzyWOfercie = true,
                        Opis = "To był najszczęśliwszy dzień w jej życiu. Co więc sprawiło, że skoczyła? Tej nocy stała na klifie i patrzyła w dół, na fale, tak jak dziesiątki razy wcześniej. Ale tym razem było inaczej – miała na sobie suknię ślubną, na rozwianych blond włosach welon i… tym razem skoczyła.",
                        Sciezka = "/images/1.jpg"

                    },
                    new Ksiazka()
                    {
                        Id = 2,
                        Tytul = "Dziewczyna z pociągu",
                        Dostepnosc = 4,
                        CzyWOfercie = true,
                        Opis = "Rachel każdego ranka dojeżdża do pracy tym samym pociągiem. Wie, że pociąg zawsze zatrzymuje się przed tym samym semaforem, dokładnie naprzeciwko szeregu domów. Zaczyna się jej nawet wydawać, że zna ludzi, którzy mieszkają w jednym z nich. Uważa, że prowadzą doskonałe życie. Gdyby tylko mogła być tak szczęśliwa jak oni.",
                        Sciezka = "/images/noPhoto.jpg"
                    },
                    new Ksiazka()
                    {
                        Id = 3,
                        Tytul = "Córka mordercy",
                        Dostepnosc = 0,
                        CzyWOfercie = true,
                        Opis = "Trudno żyć z takim piętnem. Nawet jeśli zmienisz nazwisko, i tak żyjesz w ciągłym lęku, że ktoś rzuci ci te słowa w twarz. Kathryn miała pięć lat, kiedy jej ukochany tata zabił jej rówieśniczkę i najlepszą przyjaciółkę, Elsie. Teraz jest trzydziestoletnią kobietą i nadal sobie z tym nie poradziła.",
                        Sciezka = "/images/3.jpg"

                    },
                    new Ksiazka()
                    {
                        Id = 4,
                        Tytul = "Marsjanin",
                        Dostepnosc = -5,
                        CzyWOfercie = true,
                        Opis = "Mark Watney kilka dni temu był jednym z pierwszych ludzi, którzy stanęli na Marsie. Teraz jest pewien, że będzie pierwszym, który tam umrze! Straszliwa burza piaskowa sprawia, że marsjańska ekspedycja, w której skład wchodzi Mark Watney, musi ratować się ucieczką z Czerwonej Planety.",
                        Sciezka = "/images/4.jpg"

                    },
                    new Ksiazka()
                    {
                        Id = 5,
                        Tytul = "Czarne pióro",
                        Dostepnosc = 12,
                        CzyWOfercie = true,
                        Opis = "Alaric Adlay jest znanym na całym świecie pisarzem fantastyki. Sława i pasja nie pozwoliły mu jednak odnaleźć szczęścia i spełnienia życiowego. Kiedy był już pewien, że jego życie utknęło w martwym punkcie, były przełożony złożył mu ryzykowną ofertę.",
                        Sciezka = "/images/5.jpg"

                    },
                    new Ksiazka()
                    {
                        Id = 6,
                        Tytul = "Człowiek",
                        Dostepnosc = 3,
                        CzyWOfercie = true,
                        Opis = "Planeta Ziemia. 500 000 lat w przyszłość. Ludzkość wymarła tysiące lat temu. Dwoje naukowców, Robert i jego żona June, pozostawali na orbicie Ziemi, do czasu kiedy ta znów będzie nadawać się do zamieszkania.",
                        Sciezka = "/images/6.jpg"

                    }

                    );
        }
    }
}
