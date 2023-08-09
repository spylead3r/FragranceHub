using FragranceHub.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FragranceHub.Web.Data
{
    public class FragranceHubDbContext : IdentityDbContext<ApplicationUser,IdentityRole<Guid>, Guid>
    {
        public FragranceHubDbContext(DbContextOptions<FragranceHubDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Fragrance> Fragrances { get; set; } = null!;

        public DbSet<Review> Reviews { get; set; } = null!;

        public DbSet<Wishlist> Wishlists { get; set; } = null!;

        public DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {

            Assembly configAssembly = Assembly.GetAssembly(typeof(FragranceHubDbContext)) ?? 
                Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);   
        }


    }
}