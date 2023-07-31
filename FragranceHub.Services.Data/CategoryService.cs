using FragranceHub.Services.Data.Interfaces;
using FragranceHub.Web.Data;

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
    }
}
