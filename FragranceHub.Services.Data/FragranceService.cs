
using FragranceHub.Services.Data.Interfaces;
using FragranceHub.Web.Data;
using FragranceHub.Web.ViewModels.Home;

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
            throw new NotImplementedException();
        }
    }
}
