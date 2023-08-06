
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


            IEnumerable<FragranceAllViewModel> allFragrances = await fragranceQuery
                .Where(f => f.IsActive)
                .Skip((model.CurrentPage - 1) * model.FragrancesPerPage)
                .Take(model.FragrancesPerPage)
                .Select(f => new FragranceAllViewModel()
                {
                    Id = f.Id.ToString(),
                    Name = f.Name,
                    ImageUrl = f.ImageUrl,
                    Category = f.Category.ToString()!,
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

        public async Task CreateAsync(FragranceFormModel formModel)
        {
            Fragrance fragrance = new Fragrance()
            {
                Name = formModel.Name,
                ImageUrl = formModel.ImageUrl,
                Description = formModel.Description,
                Price = formModel.Price,
                CategoryId = formModel.CategoryId,
            };

            
            await this.dbContext.Fragrances.AddAsync(fragrance);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string fragranceId)
        {
            bool result = await dbContext
                .Fragrances
                .Where(f => f.IsActive)
                .AnyAsync(f => f.Id.ToString() == fragranceId);

            return result;
        }

        public async Task<FragranceFormModel> GetFragranceForEditByIdAsync(string houseId)
        {
            Fragrance fragrance = await dbContext
                .Fragrances
                .Include(f => f.Category)
                .Where(f => f.IsActive)
                .FirstAsync(f => f.Id.ToString() == houseId);

            return new FragranceFormModel
            {
                Name = fragrance.Name,
                Price = fragrance.Price,
                ImageUrl = fragrance.ImageUrl,
                Description = fragrance.Description,
                CategoryId = fragrance.CategoryId
            };
        }

        public async Task EditFragranceByIdAndFormModelAsync(string fragranceId, FragranceFormModel formModel)
        {
            Fragrance fragrance = await dbContext
                .Fragrances
                .Where(f => f.IsActive)
                .FirstAsync(f => f.Id.ToString() == fragranceId);

            fragrance.Name = formModel.Name;
            fragrance.ImageUrl = formModel.ImageUrl;
            fragrance.Description = formModel.Description;
            fragrance.Price = formModel.Price;
            fragrance.CategoryId = formModel.CategoryId;

            await dbContext.SaveChangesAsync();
        }


        public async Task<FragrancePreDeleteViewModel> GetHouseForDeleteByIdAsync(string houseId)
        {
            Fragrance fragrance = await dbContext
                .Fragrances
                .Where(f => f.IsActive)
                .FirstAsync(f => f.Id.ToString() == houseId);

            return new FragrancePreDeleteViewModel
            {
                Name = fragrance.Name,
                ImageUrl = fragrance.ImageUrl
            };
        }

        public async Task DeleteHouseByIdAsync(string houseId)
        {
            Fragrance houseToDelete = await dbContext
                .Fragrances
                .Where(f => f.IsActive)
                .FirstAsync(f => f.Id.ToString() == houseId);

            houseToDelete.IsActive = false;

            await dbContext.SaveChangesAsync();
        }

        public Task<FragranceDetailsViewModel> GetDetailsByIdAsync(string houseId)
        {
            throw new NotImplementedException();
        }
    }
}
