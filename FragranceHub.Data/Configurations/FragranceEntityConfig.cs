﻿using FragranceHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace FragranceHub.Data.Configurations
{
    public class FragranceEntityConfig : IEntityTypeConfiguration<Fragrance>
    {
        public void Configure(EntityTypeBuilder<Fragrance> builder)
        {
            builder
                .Property(f => f.PublishedOnDate)
                .HasDefaultValue(DateTime.UtcNow);

            builder
                .Property(f => f.IsActive)
                .HasDefaultValue(true);

            builder.HasKey(f => f.Id);

            builder.HasOne(f => f.Category)
                   .WithMany(c => c.Fragrances)
                   .HasForeignKey(f => f.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.User)
                   .WithMany(u => u.OwnedFragrances)
                   .HasForeignKey(f => f.UserId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasData(this.GenerateFragrances());

        }

        private Fragrance[] GenerateFragrances()
        {
            ICollection<Fragrance> fragrances = new HashSet<Fragrance>();

            Fragrance fragrance;

            fragrance = new Fragrance()
            {
                Id = Guid.NewGuid(),
                Name = "Creed Aventus",
                Description = "",
                Price = 620.00m,
                ImageUrl = "https://cdn.notinoimg.com/list_2k//chanel/3145891073706_01-o__211007.jpg",
                CategoryId = 1,
                IsApproved = true
            };

            fragrances.Add(fragrance);

            fragrance = new Fragrance()
            {
                Id = Guid.NewGuid(),
                Name = "Bleu De Chanel",
                Description = "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.",
                Price = 620.00m,
                ImageUrl = "https://cdn.notinoimg.com/list_2k//creed/3508441104662_01-o__230320.jpg",
                CategoryId = 1,
                IsApproved = true
            };

            fragrances.Add(fragrance);

            fragrance = new Fragrance()
            {
                Id = Guid.NewGuid(),
                Name = "Bleu De Chanel",
                Description = "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.",
                Price = 620.00m,
                ImageUrl = "https://cdn.notinoimg.com/list_2k//creed/3508441104662_01-o__230320.jpg",
                CategoryId = 1,
                IsApproved = true
            };

            fragrances.Add(fragrance);

            fragrance = new Fragrance()
            {
                Id = Guid.NewGuid(),
                Name = "Bleu De Chanel",
                Description = "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.",
                Price = 620.00m,
                ImageUrl = "https://cdn.notinoimg.com/list_2k//creed/3508441104662_01-o__230320.jpg",
                CategoryId = 1,
                IsApproved = true
            };

            fragrances.Add(fragrance);

            fragrance = new Fragrance()
            {
                Id = Guid.NewGuid(),
                Name = "Bleu De Chanel",
                Description = "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.",
                Price = 620.00m,
                ImageUrl = "https://cdn.notinoimg.com/list_2k//creed/3508441104662_01-o__230320.jpg",
                CategoryId = 1,
                IsApproved = true
            };

            fragrances.Add(fragrance);

            fragrance = new Fragrance()
            {
                Id = Guid.NewGuid(),
                Name = "Bleu De Chanel",
                Description = "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.",
                Price = 620.00m,
                ImageUrl = "https://cdn.notinoimg.com/list_2k//creed/3508441104662_01-o__230320.jpg",
                CategoryId = 1,
                IsApproved = true
            };

            fragrances.Add(fragrance);

            fragrance = new Fragrance()
            {
                Id = Guid.NewGuid(),
                Name = "Bleu De Chanel",
                Description = "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.",
                Price = 620.00m,
                ImageUrl = "https://cdn.notinoimg.com/list_2k//creed/3508441104662_01-o__230320.jpg",
                CategoryId = 1,
                IsApproved = true
            };

            fragrances.Add(fragrance);



            return fragrances.ToArray();
        }
    }
}
