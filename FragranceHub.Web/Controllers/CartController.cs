using FragranceHub.Services.Data;
using FragranceHub.Services.Data.Interfaces;
using FragranceHub.Web.Infrastructure.Extensions;
using FragranceHub.Web.ViewModels.Cart;
using FragranceHub.Web.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

using static FragranceHub.Common.NotificationMessagesConstants;

namespace FragranceHub.Web.Controllers
{
    public class CartController : Controller
    {

        private readonly ICartService cartService;


        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Mine()
        {
            string userId = User.GetId()!;
            var cartItems = await cartService.GetCartItems(userId);
            var totalPrice = await cartService.CalculateTotalPrice(userId);

            var model = new ShoppingCartViewModel
            {
                CartItems = cartItems,
                TotalPrice = totalPrice
            };

            return View(model);
        }

        public async Task<IActionResult> AddToCart(string fragranceId, int quantity)
        {
            string userId = User.GetId()!;
            await cartService.AddToCart(fragranceId, userId, quantity);

            TempData[SuccessMessage] = "Successfully added fragrance to your card.";

            return RedirectToAction("Mine", "Cart");
        }

        public async Task<IActionResult> RemoveFromCart(string fragranceId)
        {
            string userId = User.GetId()!;
            await cartService.RemoveFromCart(fragranceId, userId);

            TempData[ErrorMessage] = "Successfully removed fragrance from your card.";

            return RedirectToAction("Mine", "Cart");
        }


    }
}
