
namespace FragranceHub.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<string>> AllCategoryNamesAsync();


    }
}
