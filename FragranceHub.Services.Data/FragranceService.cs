
using FragranceHub.Services.Data.Interfaces;
using FragranceHub.Web.Data;
using FragranceHub.Web.ViewModels.Home;
using Microsoft.EntityFrameworkCore;

namespace FragranceHub.Services.Data
{
    public class FragranceService : IFragranceService
    {
        private readonly FragranceHubDbContext dbContext;

        public FragranceService(FragranceHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<IndexViewModel>> LastThreeFragrancesAsync()
        {
            IEnumerable<IndexViewModel> lastThreeFragrances = await dbContext
                .Fragrances
                .OrderByDescending(f => f.PublishedOn)
                .Take(3)
                .Select(f => new IndexViewModel()
                {
                    Id = f.Id.ToString(),
                    Name = f.Name,
                    ImageUrl = f.ImageUrl
                })
                .ToArrayAsync();

            return lastThreeFragrances;
        }
    }
}
