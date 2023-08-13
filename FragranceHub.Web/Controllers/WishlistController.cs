using FragranceHub.Services.Data;
using FragranceHub.Services.Data.Interfaces;
using FragranceHub.Web.Infrastructure.Extensions;
using FragranceHub.Web.ViewModels.Wishlist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static FragranceHub.Common.NotificationMessagesConstants;

namespace FragranceHub.Web.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        private readonly IWishlistService wishlistService;
        public WishlistController(IWishlistService wishlistService)
        {
            this.wishlistService = wishlistService;
        }


        public async Task<IActionResult> Index()
        {
            return View();
        }


       
        public async Task<IActionResult> AddToFavorites(string fragranceId)
        {
            string userId = User.GetId()!; // Get the current user's ID
            bool success = await wishlistService.AddToFavoritesAsync(fragranceId, userId);

            if (success)
            {

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData[ErrorMessage] = "Failed to add fragrance to favorites.";

                return RedirectToAction("All", "Fragrance");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Remove(string fragranceId)
        {
            string userId = User.GetId()!;
           

            try
            {
                await wishlistService.RemoveFromFavoritesAsync(fragranceId, userId);


                return RedirectToAction("Wishlist","Wishlist"); 

            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }
        }


        [HttpGet]
        public async Task<IActionResult> Wishlist()
        {
            var userId = User.GetId();
            var fragrancesInWishlist = await wishlistService.GetFragrancesInWishlistAsync(userId!);

            var viewModel = new WishlistViewModel
            {
                Fragrances = fragrancesInWishlist
            };

            return View(viewModel);
        }


    }
}
