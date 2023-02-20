using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ksiegarnia.Models
{
    public class Kategoria
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = " Zbyt dluga nazwa")]
        public string Nazwa { get; set; }

        public ICollection<KsiazkaKategoria> KsiazkaKategoria { get; set; }

        public Kategoria() { }
    }
}
