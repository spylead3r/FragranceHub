﻿using FragranceHub.Services.Data;
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


        [HttpPost]
        public async Task<IActionResult> AddToFavorites(Guid fragranceId)
        {
            string userId = User.GetId()!; // Get the current user's ID
            bool success = await wishlistService.AddToFavorites(fragranceId, userId);

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

        [HttpPost]
        public async Task<IActionResult> Remove(Guid fragranceId)
        {
            string userId = User.GetId()!;
           

            try
            {
                await wishlistService.RemoveFromFavorites(fragranceId, userId);


                return RedirectToAction("All","Fragrance"); 

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
            var fragrancesInWishlist = await wishlistService.GetFragrancesInWishlist(userId!);

            var viewModel = new WishlistViewModel
            {
                Fragrances = fragrancesInWishlist
            };

            return View(viewModel);
        }


    }
}
