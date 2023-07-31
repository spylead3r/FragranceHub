
using FragranceHub.Data.Models;
using FragranceHub.Services.Data.Interfaces;
using FragranceHub.Services.Data.Models.Fragrance;
using FragranceHub.Web.Data;
using FragranceHub.Web.ViewModels;
using FragranceHub.Web.ViewModels.Fragrance;
using FragranceHub.Web.ViewModels.Fragrance.Enums;
using FragranceHub.Web.ViewModels.Home;
using Microsoft.EntityFrameworkCore;

namespace FragranceHub.Services.Data
{
    public class FragranceService : IFragranceService
    {
        private readonly FragranceHubDbContext dbContext;
        private readonly ICategoryService categoryService;

        public FragranceService(FragranceHubDbContext dbContext, ICategoryService categoryService)
        {
            this.dbContext = dbContext;
            this.categoryService = categoryService;
        }


        public async Task<AllFragrancesFilteredModel> AllFragrancesAsync(AllFragrancesQueryModel model)
        {
            IQueryable<Fragrance> fragranceQuery = dbContext
                .Fragrances
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.Category))
            {
                fragranceQuery = fragranceQuery
                    .Where(f => f.Category.Name == model.Category);
            }

            if (!string.IsNullOrWhiteSpace(model.SearchString))
            {
                string wildCard = $"%{model.SearchString.ToLower()}%";
                fragranceQuery = fragranceQuery
                    .Where(f => EF.Functions.Like(f.Name, wildCard) ||
                    EF.Functions.Like(f.Description, wildCard));
            }

            fragranceQuery = model.FragranceSorting switch
            {
                FragranceSorting.PriceAscending => fragranceQuery
                .OrderByDescending(f => f.Price),

                FragranceSorting.PriceDescending => fragranceQuery
               .OrderBy(f => f.Price)
            };


            IEnumerable<FragranceAllViewModel> allFragrances = await fragranceQuery.
                Skip((model.CurrentPage - 1) * model.FragrancesPerPage)
                .Take(model.FragrancesPerPage)
                .Select(f => new FragranceAllViewModel()
                {
                    Id = f.Id.ToString(),
                    Name = f.Name,
                    ImageUrl = f.ImageUrl,
                    Category = f.Category.ToString(),
                    Price = f.Price
                })
                .ToArrayAsync();

            int totalFragrances = fragranceQuery.Count();

            return new AllFragrancesFilteredModel()
            {
                TotalFragrancesCount = totalFragrances,
                Fragrances = allFragrances
            };
        }
    }
}
