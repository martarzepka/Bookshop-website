using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ksiegarnia.Models
{
    public class Autor
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Imie { get; set; }

        [Required]
        public string Nazwisko { get; set; }

        public ICollection<KsiazkaAutor> KsiazkaAutor { get; set; }

        public Autor() { }
    }
}
