using FragranceHub.Web.ViewModels.Fragrance;


namespace FragranceHub.Services.Data.Models.Fragrance
{
    public class AllFragrancesFilteredModel
    {
        public AllFragrancesFilteredModel()
        {
            this.Fragrances = new HashSet<FragranceAllViewModel>();
        }

        public int TotalFragrancesCount { get; set; }

        public IEnumerable<FragranceAllViewModel> Fragrances { get; set; }

    }
}
