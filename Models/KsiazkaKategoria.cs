namespace Ksiegarnia.Models
{
    public class KsiazkaKategoria
    {
        public int KsiazkaId { get; set; }
        public Ksiazka Ksiazka { get; set; }
        public int KategoriaId { get; set; }
        public Kategoria Kategoria { get; set; }
    }
}
