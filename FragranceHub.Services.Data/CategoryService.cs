using FragranceHub.Services.Data.Interfaces;
using FragranceHub.Web.Data;
using FragranceHub.Web.ViewModels.Category;
using Microsoft.EntityFrameworkCore;


namespace FragranceHub.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly FragranceHubDbContext dbContext;


        public CategoryService(FragranceHubDbContext dbContext)
        {
            this.dbContext = dbContext;       
        }

        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            IEnumerable<string> allNames = await this.dbContext.Categories
                .Select(c => c.Name)
                .ToArrayAsync();

            return allNames;
        }

        public async Task<IEnumerable<FragranceByCategoryForm>> GetMenFragrances()
        {
            IEnumerable<FragranceByCategoryForm> menFragrances =
               await this.dbContext.Fragrances
               .Where(f => f.Category.Id == 1)
                .Select(f => new FragranceByCategoryForm()
                {
                    Name = f.Name,
                    ImageUrl = f.ImageUrl,
                    Price = f.Price
                })
                .ToListAsync();

            return menFragrances;
        }

        public async Task<IEnumerable<FragranceByCategoryForm>> GetWomenFragrances()
        {
            IEnumerable<FragranceByCategoryForm> womenFragrances =
               await this.dbContext.Fragrances
               .Where(f => f.Category.Id == 2)
                .Select(f => new FragranceByCategoryForm()
                {
                    Name = f.Name,
                    ImageUrl = f.ImageUrl,
                    Price = f.Price
                })
                .ToListAsync();

            return womenFragrances;
        }

        public async Task<IEnumerable<FragranceByCategoryForm>> GetUnisexFragrances()
        {
            IEnumerable<FragranceByCategoryForm> unisexFragrances =
               await this.dbContext.Fragrances
               .Where(f => f.Category.Id == 3)
                .Select(f => new FragranceByCategoryForm()
                {
                    Name = f.Name,
                    ImageUrl = f.ImageUrl,
                    Price = f.Price
                })
                .ToListAsync();

            return unisexFragrances;
        }
    }
}
