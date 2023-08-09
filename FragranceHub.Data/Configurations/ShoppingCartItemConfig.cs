using FragranceHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragranceHub.Data.Configurations
{
    public class ShoppingCartItemConfig : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {

            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Fragrance)
                   .WithMany()
                   .HasForeignKey(s => s.FragranceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.ShoppingCart)
                   .WithMany()
                   .HasForeignKey(s => s.CartId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

