using System.ComponentModel.DataAnnotations;

namespace Ksiegarnia.Models
{
    public class PozycjaWKoszyku
    {
        [Required]
        public int KsiazkaId { get; set; }
        [Required]
        public Ksiazka Ksiazka { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Liczba { get; set; }
    }
}
