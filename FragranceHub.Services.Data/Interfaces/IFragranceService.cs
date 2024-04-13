
using FragranceHub.Data.Models;
using FragranceHub.Services.Data.Models.Fragrance;
using FragranceHub.Web.ViewModels.Category;
using FragranceHub.Web.ViewModels.Fragrance;
using FragranceHub.Web.ViewModels.Home;

namespace FragranceHub.Services.Data.Interfaces
{
    public interface IFragranceService
    {
        Task<AllFragrancesFilteredModel> AllFragrancesAsync(AllFragrancesQueryModel model);

        Task CreateAsync(FragranceFormModel formModel);

        Task<bool> ExistsByIdAsync(string fragranceId);

        Task<FragranceFormModel> GetFragranceForEditByIdAsync(string fragranceId);

        Task EditFragranceByIdAndFormModelAsync(string fragranceId, FragranceFormModel formModel);

        Task<FragranceDetailsViewModel> GetDetailsByIdAsync(string fragranceId);
        
        Task<FragrancePreDeleteViewModel> GetFragranceForDeleteByIdAsync(string houseId);
        
        Task DeleteFragranceByIdAsync(string houseId);

        Task UpdateFragranceAccordsAsync(string fragranceId, FragranceAccordsModel accords);

        Task<FragranceAccordsModel> GetAccordsByFragranceIdAsync(string fragranceId);



    }
}
