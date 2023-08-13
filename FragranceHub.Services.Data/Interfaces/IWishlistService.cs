using FragranceHub.Web.ViewModels.Fragrance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragranceHub.Services.Data.Interfaces
{
    public interface IWishlistService
    {
        Task<bool> AddToFavoritesAsync(string fragranceId, string userId);

        Task<List<FragranceAllViewModel>> GetFragrancesInWishlistAsync(string userId);

        Task<bool> RemoveFromFavoritesAsync(string fragranceId, string userId);
    }
}
