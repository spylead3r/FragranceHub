using FragranceHub.Data.Models;
using FragranceHub.Services.Data.Interfaces;
using FragranceHub.Web.Data;
using FragranceHub.Web.ViewModels.Fragrance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragranceHub.Services.Data
{
    public class WishlistService : IWishlistService
    {
        private readonly FragranceHubDbContext dbContext;

        public WishlistService(FragranceHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddToFavorites(Guid fragranceId, string userId)
        {
            var fragrance = await dbContext.Fragrances.FindAsync(fragranceId);
            var user = await dbContext.Users.FindAsync(userId);

            if (fragrance == null || user == null)
            {
                return false;
            }

            var wishlist = await dbContext.Wishlists
                .Include(w => w.Fragrances)
                .FirstOrDefaultAsync(w => w.UserId.ToString() == userId);

            if (wishlist == null)
            {
                wishlist = new Wishlist { UserId = Guid.Parse(userId) };
                dbContext.Wishlists.Add(wishlist);
            }

            if (!wishlist.Fragrances.Contains(fragrance))
            {
                wishlist.Fragrances.Add(fragrance);
                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<FragranceAllViewModel>> GetFragrancesInWishlist(string userId)
        {
            var wishlist = await dbContext.Wishlists
                .Include(w => w.Fragrances)
                .FirstOrDefaultAsync(w => w.UserId.ToString() == userId);

            if (wishlist != null)
            {
                var fragrancesInWishlist = wishlist.Fragrances
                    .Select(f => new FragranceAllViewModel
                    {
                        Id = f.Id.ToString(),
                        ImageUrl = f.ImageUrl,
                        Name = f.Name,
                        Price = f.Price,
                        // Other properties you want to display
                    })
                    .ToList();

                return fragrancesInWishlist;
            }

            return new List<FragranceAllViewModel>();
        }
    }
}
