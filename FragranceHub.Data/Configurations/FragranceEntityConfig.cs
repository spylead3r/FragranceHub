using FragranceHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace FragranceHub.Data.Configurations
{
    public class FragranceEntityConfig : IEntityTypeConfiguration<Fragrance>
    {
        public void Configure(EntityTypeBuilder<Fragrance> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(f => f.Category)
                   .WithMany(c => c.Fragrances)
                   .HasForeignKey(f => f.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.User)
                   .WithMany(u => u.OwnedFragrances)
                   .HasForeignKey(f => f.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }

        public class ReviewConfiguration : IEntityTypeConfiguration<Review>
        {
            public void Configure(EntityTypeBuilder<Review> builder)
            {
                builder.HasKey(r => r.Id);

                builder.HasOne(r => r.Fragrance)
                       .WithMany(f => f.Reviews)
                       .HasForeignKey(r => r.FragranceId)
                       .OnDelete(DeleteBehavior.Restrict); ;

                builder.HasOne(r => r.User)
                       .WithMany(u => u.PostedReviews)
                       .HasForeignKey(r => r.UserId)
                       .OnDelete(DeleteBehavior.Restrict);
            }
        }

        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            // Configure the primary key
            builder.HasKey(s => s.Id);

            // Configure the many-to-one relationship with Fragrance
            builder.HasOne(s => s.Fragrance)
                   .WithMany()
                   .HasForeignKey(s => s.FragranceId)
                   .OnDelete(DeleteBehavior.Restrict); 

            // Configure the many-to-one relationship with ApplicationUser (User)
            builder.HasOne(s => s.User)
                   .WithMany()
                   .HasForeignKey(s => s.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
