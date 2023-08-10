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
        Task<bool> AddToFavorites(Guid fragranceId, string userId);

        Task<List<FragranceAllViewModel>> GetFragrancesInWishlist(string userId);

        Task<bool> RemoveFromFavorites(Guid fragranceId, string userId);
    }
}
