namespace FragranceHub.Web.ViewModels.Fragrance
{
    public class FragranceDetailsViewModel : FragranceAllViewModel
    {
        public string Description { get; set; } = null!;

        //Accords
        public int Woody { get; set; }
        public int Citrus { get; set; }
        public int Floral { get; set; }
        public int Spicy { get; set; }
        public int Fruity { get; set; }
        public int Aromatic { get; set; }
        public int Green { get; set; }
        public int Musky { get; set; }
        public int Herbal { get; set; }
    }
}
