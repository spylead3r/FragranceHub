
using FragranceHub.Web.ViewModels.Category;

namespace FragranceHub.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<string>> AllCategoryNamesAsync();

        Task<IEnumerable<FragranceSelectCategoryFormModel>> AllCategoriesAsync();

        Task<bool> ExistsByIdAsync(int id);

        Task<IEnumerable<FragranceByCategoryForm>> GetMenFragrancesAsync();

        Task<IEnumerable<FragranceByCategoryForm>> GetWomenFragrancesAsync();

        Task<IEnumerable<FragranceByCategoryForm>> GetUnisexFragrancesAsync();


    }
}
