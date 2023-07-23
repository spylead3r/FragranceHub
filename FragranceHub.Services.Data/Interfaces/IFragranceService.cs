
using FragranceHub.Data.Models;
using FragranceHub.Web.ViewModels.Home;

namespace FragranceHub.Services.Data.Interfaces
{
    public interface IFragranceService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeFragrancesAsync();
    }
}
