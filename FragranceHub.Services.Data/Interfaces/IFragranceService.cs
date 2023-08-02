
using FragranceHub.Data.Models;
using FragranceHub.Services.Data.Models.Fragrance;
using FragranceHub.Web.ViewModels.Fragrance;
using FragranceHub.Web.ViewModels.Home;

namespace FragranceHub.Services.Data.Interfaces
{
    public interface IFragranceService
    {
        Task<AllFragrancesFilteredModel> AllFragrancesAsync(AllFragrancesQueryModel model);

        
    }
}
