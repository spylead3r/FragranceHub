
using System.ComponentModel.DataAnnotations;


namespace FragranceHub.Web.ViewModels.Fragrance
{
    public class FragranceFormModel
    {
        [Display()]

        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
