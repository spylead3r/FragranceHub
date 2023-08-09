﻿using FragranceHub.Services.Data;
using FragranceHub.Services.Data.Interfaces;
using FragranceHub.Web.Infrastructure.Extensions;
using FragranceHub.Web.ViewModels.Wishlist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            var userId = User.GetId();
            var success = await wishlistService.AddToFavorites(fragranceId, userId);

            if (success)
            {
                return Ok();
            }

            return BadRequest("Unable to add fragrance to favorites.");
        }


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
