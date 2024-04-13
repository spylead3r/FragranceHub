
using FragranceHub.Web.ViewModels.Category;
using System.ComponentModel.DataAnnotations;
using static FragranceHub.Common.EntityValidationConstants.Fragrance;


namespace FragranceHub.Web.ViewModels.Fragrance
{
    public class FragranceFormModel
    {
        public FragranceFormModel()
        {
            Categories = new HashSet<FragranceSelectCategoryFormModel>();
        }
        [Required]
        [StringLength(FragranceNameMaxLength, MinimumLength = FragranceNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Display(Name = "Image Link")]
        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength)]
        public string ImageUrl { get; set; } = null!;

        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<FragranceSelectCategoryFormModel> Categories { get; set; }

    }
}
