
using FragranceHub.Web.ViewModels.Category;

namespace FragranceHub.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<string>> AllCategoryNamesAsync();

        Task<IEnumerable<FragranceByCategoryForm>> GetMenFragrances();

        Task<IEnumerable<FragranceByCategoryForm>> GetWomenFragrances();

        Task<IEnumerable<FragranceByCategoryForm>> GetUnisexFragrances();


    }
}
