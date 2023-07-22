using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FragranceHub.Data.Models;

namespace FragranceHub.Data.Configurations
{
    public class ReviewEntityConfig : IEntityTypeConfiguration<Review>
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
}
