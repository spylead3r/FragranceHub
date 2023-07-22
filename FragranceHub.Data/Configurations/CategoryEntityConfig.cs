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
    public class CategoryEntityConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

        private Category[] GenerateCategories()
        {

            ICollection<Category> categories = new HashSet<Category>();
            Category category;

            category = new Category()
            {
                Id = 1,
                Name = "Men"

            };

            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Women"

            };

            categories.Add(category);


            category = new Category()
            {
                Id = 3,
                Name = "Unisex"

            };

            categories.Add(category);


            return categories.ToArray();
        }
    }
}
