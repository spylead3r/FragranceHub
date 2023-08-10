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

                ApplicationUser? user = await dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

                if (user == null)
                {
                    return false; // User not found, return false
                }

                // Check if the fragrance is already in the user's wishlist
                var wishlist = await dbContext.Wishlists
                    .Include(w => w.Fragrances)
                    .SingleOrDefaultAsync(w => w.UserId == user.Id);

                if (wishlist == null)
                {
                    // Create a new wishlist for the user if it doesn't exist
                    wishlist = new Wishlist
                    {
                        UserId = user.Id
                    };

                    dbContext.Wishlists.Add(wishlist);
                    await dbContext.SaveChangesAsync(); // Save changes to the database
                }

                // Check if the fragrance is already in the wishlist
                var fragranceExistsInWishlist = wishlist.Fragrances.Any(f => f.Id == fragranceId);

                if (!fragranceExistsInWishlist)
                {
                    var fragrance = await dbContext.Fragrances.FindAsync(fragranceId);
                    if (fragrance != null)
                    {
                        wishlist.Fragrances.Add(fragrance);
                        await dbContext.SaveChangesAsync(); // Save changes to the database
                    }
                }

                return true;
 
        }

        public async Task<bool> RemoveFromFavorites(Guid fragranceId, string userId)
        {
            try
            {
                ApplicationUser? user = await dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);


                if (user == null)
                {
                    return false; // User not found, return false
                }

                var wishlist = await dbContext.Wishlists
                    .Include(w => w.Fragrances)
                    .SingleOrDefaultAsync(w => w.UserId.ToString() == userId);

                if (wishlist == null)
                {
                    return false; // Wishlist not found, return false
                }

                var fragrance = await dbContext.Fragrances.FindAsync(fragranceId);

                if (fragrance != null && wishlist.Fragrances.Contains(fragrance))
                {
                    wishlist.Fragrances.Remove(fragrance);
                    await dbContext.SaveChangesAsync();
                    return true; // Removal successful
                }
                else
                {
                    return false; // Fragrance not found in wishlist, return false
                }
            }
            catch (Exception)
            {
                return false; // An error occurred, return false
            }
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
