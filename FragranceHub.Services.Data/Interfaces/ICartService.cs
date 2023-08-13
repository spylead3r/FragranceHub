
using FragranceHub.Data.Models;

namespace FragranceHub.Services.Data.Interfaces
{
    public interface ICartService
    {
        Task AddToCart(string fragranceId, string userId, int quantity);
        Task RemoveFromCart(string fragranceId, string userId);
        Task<decimal> CalculateTotalPrice(string userId);
        Task<List<ShoppingCartItem>> GetCartItems(string userId);

    }
}
