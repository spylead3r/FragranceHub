using FragranceHub.Data.Models;
using FragranceHub.Services.Data.Interfaces;
using FragranceHub.Web.Data;
using FragranceHub.Web.ViewModels.Fragrance;
using Microsoft.EntityFrameworkCore;

namespace FragranceHub.Services.Data
{
    public class WishlistService : IWishlistService
    {
        private readonly FragranceHubDbContext dbContext;

        public WishlistService(FragranceHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddToFavoritesAsync(string fragranceId, string userId)
        {

                ApplicationUser? user = await dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString().ToLower() == userId.ToLower());

                if (user == null)
                {
                    return false; 
                }

             
                var wishlist = await dbContext.Wishlists
                    .Include(w => w.Fragrances)
                    .SingleOrDefaultAsync(w => w.UserId.ToString().ToLower() == user.Id.ToString().ToLower());

                if (wishlist == null)
                {
                    wishlist = new Wishlist
                    {
                        UserId = user.Id
                    };

                    dbContext.Wishlists.Add(wishlist);
                    await dbContext.SaveChangesAsync(); 
                }

                
                var fragranceExistsInWishlist = wishlist.Fragrances.Any(f => f.Id.ToString().ToLower() == fragranceId.ToLower());

                if (!fragranceExistsInWishlist)
                {
                    var fragrance = await dbContext.Fragrances.FirstOrDefaultAsync(f => f.Id.ToString().ToLower() == fragranceId.ToLower());
                    if (fragrance != null)
                    {
                        wishlist.Fragrances.Add(fragrance);
                        await dbContext.SaveChangesAsync(); 
                    }
                }

                return true;
 
        }

        public async Task<bool> RemoveFromFavoritesAsync(string fragranceId, string userId)
        {

                ApplicationUser? user = await dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);


                if (user == null)
                {
                    return false; 
                }

                var wishlist = await dbContext.Wishlists
                    .Include(w => w.Fragrances)
                    .SingleOrDefaultAsync(w => w.UserId.ToString().ToLower() == userId.ToLower());

                if (wishlist == null)
                {
                    return false; 
                }

                var fragrance = await dbContext.Fragrances.FirstOrDefaultAsync(f => f.Id.ToString().ToLower() == fragranceId.ToLower());

                if (fragrance != null && wishlist.Fragrances.Contains(fragrance))
                {
                    wishlist.Fragrances.Remove(fragrance);
                    await dbContext.SaveChangesAsync();
                    return true; 
                }
                else
                {
                    return false; 
                }
            

        }


        public async Task<List<FragranceAllViewModel>> GetFragrancesInWishlistAsync(string userId)
        {
            var wishlist = await dbContext.Wishlists
                .Include(w => w.Fragrances)
                .FirstOrDefaultAsync(w => w.UserId.ToString().ToLower() == userId.ToLower());

            if (wishlist != null)
            {
                var fragrancesInWishlist = wishlist.Fragrances
                    .Select(f => new FragranceAllViewModel
                    {
                        Id = f.Id.ToString(),
                        ImageUrl = f.ImageUrl,
                        Name = f.Name,
                        Price = f.Price,                      
                    })
                    .ToList();

                return fragrancesInWishlist;
            }

            return new List<FragranceAllViewModel>();
        }
    }
}
