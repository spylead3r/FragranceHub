using FragranceHub.Data.Models;
using FragranceHub.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragranceHub.Services.Data
{
    public class ShoppingCartService
    {
        private readonly FragranceHubDbContext dbContext;

        public ShoppingCartService(FragranceHubDbContext dbContext)
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

            var existingCartItem = cart.CartItems.FirstOrDefault(item => item.FragranceId == fragranceId);
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
                dbContext.ShoppingCartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromCart(string fragranceId, string userId)
        {
            var cart = await GetOrCreateCart(userId);

            var cartItem = cart.CartItems.FirstOrDefault(item => item.FragranceId == fragranceId);
            if (cartItem != null)
            {
                await dbContext.ShoppingCartItems.Remove(cartItem);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<decimal> CalculateTotalPrice(string userId)
        {
            var cart = await GetOrCreateCart(userId);
            return cart.(item => item.Quantity * item.Fragrance.Price);
        }

        private async Task<ShoppingCart> GetOrCreateCart(string userId)
        {
            var cart = await dbContext.ShoppingCarts.FirstOrDefaultAsync(c => c.UserId.ToString() == userId);

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

