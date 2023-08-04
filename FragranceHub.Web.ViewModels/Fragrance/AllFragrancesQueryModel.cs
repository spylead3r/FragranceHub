using System.ComponentModel.DataAnnotations;
namespace FragranceHub.Web.ViewModels.Fragrance
{
    using FragranceHub.Web.ViewModels.Fragrance.Enums;

    using static FragranceHub.Common.GeneralAppConstants;

    public class AllFragrancesQueryModel
    {
        public AllFragrancesQueryModel()
        {
            this.Categories = new HashSet<string>();
            this.Fragrances = new HashSet<FragranceAllViewModel>();
            this.CurrentPage = DefaultPage;
            this.FragrancesPerPage = EntitiesPerPage;
        }

        public string? Category { get; set; }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Fragrances By")]
        public FragranceSorting FragranceSorting { get; set; }

        public int CurrentPage { get; set; }

        public int FragrancesPerPage { get; set; }

        public int TotalFragrances { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<FragranceAllViewModel> Fragrances { get; set; }

    }
}
