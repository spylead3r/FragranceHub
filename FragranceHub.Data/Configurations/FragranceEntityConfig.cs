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
    }
}
