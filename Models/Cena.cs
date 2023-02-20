using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ksiegarnia.Models
{
    public class Cena
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataOd { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataDo { get; set; }

        [Required]
        [Range(0, 10000)]
        public float Wartosc { get; set; }

        [Required]
        public bool CzyPromocja { get; set; }

        public Ksiazka Ksiazka { get; set; }

        [Required]
        public int KsiazkaId { get; set; }

        public Cena()
        {
        }
    }
}
