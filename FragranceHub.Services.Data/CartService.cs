
using FragranceHub.Data.Models;
using FragranceHub.Services.Data.Interfaces;
using FragranceHub.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace FragranceHub.Services.Data
{
    public class CartService : ICartService
    {
        private readonly FragranceHubDbContext dbContext;

        public CartService(FragranceHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddToCart(string fragranceId, string userId, int quantity)
        {
            var fragrance = await dbContext.Fragrances.FirstOrDefaultAsync(f => f.Id.ToString() == fragranceId);

            if (fragrance == null)
            {
                return;
            }

            var cart = await GetOrCreateCart(userId);

            var existingCartItem = cart.CartItems.FirstOrDefault(item => item.FragranceId.ToString() == fragranceId.ToLower());

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity; 
            }
            else
            {
                var cartItem = new ShoppingCartItem
                {
                    FragranceId = Guid.Parse(fragranceId),
                    Quantity = quantity,
                    ShoppingCart = cart
                };
                cart.CartItems.Add(cartItem);
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<decimal> CalculateTotalPrice(string userId)
        {
            var cart = await GetOrCreateCart(userId);

            
            await dbContext.Entry(cart).Collection(c => c.CartItems).LoadAsync();

            
            var fragranceIds = cart.CartItems.Select(item => item.FragranceId).ToList();
          
            var fragrances = await dbContext.Fragrances
                .Where(f => fragranceIds.Contains(f.Id))
                .ToListAsync();

            decimal totalPrice = 0;

            foreach (var item in cart.CartItems)
            {
                var fragrance = fragrances.FirstOrDefault(f => f.Id == item.FragranceId);
                if (fragrance != null && fragrance.Price != null)
                {
                    totalPrice += item.Quantity * fragrance.Price;
                }
            }

            cart.TotalPrice = totalPrice;
            await dbContext.SaveChangesAsync();

            return cart.TotalPrice;
        }

        public async Task<List<ShoppingCartItem>> GetCartItems(string userId)
        {
            var cart = await GetOrCreateCart(userId);
            return cart.CartItems.ToList();
        }

        public async Task RemoveFromCart(string fragranceId, string userId)
        {
            var cart = await GetOrCreateCart(userId);

            var cartItem = cart.CartItems.FirstOrDefault(item => item.FragranceId.ToString() == fragranceId);
            if (cartItem != null)
            {
                cart.CartItems.Remove(cartItem);
                await dbContext.SaveChangesAsync();

                
                await CalculateTotalPrice(userId);
            }
        }



        private async Task<ShoppingCart> GetOrCreateCart(string userId)
        {
            var cart = await dbContext.ShoppingCarts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.UserId.ToString() == userId);

            if (cart == null)
            {
                cart = new ShoppingCart
                {
                    UserId = Guid.Parse(userId)
                };

                await dbContext.ShoppingCarts.AddAsync(cart);
                await dbContext.SaveChangesAsync();
            }

            return cart;
        }
    }
}
