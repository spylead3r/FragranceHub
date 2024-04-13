
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


        public async Task<FragrancePreDeleteViewModel> GetFragranceForDeleteByIdAsync(string houseId)
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

        public async Task DeleteFragranceByIdAsync(string houseId)
        {
            Fragrance houseToDelete = await dbContext
                .Fragrances
                .Where(f => f.IsActive)
                .FirstAsync(f => f.Id.ToString() == houseId);

            houseToDelete.IsActive = false;

            await dbContext.SaveChangesAsync();
        }

        public async Task<FragranceDetailsViewModel> GetDetailsByIdAsync(string fragranceId)
        {
            Fragrance fragrance = await dbContext
                .Fragrances
                .Include(f => f.Category)
                .Where(f => f.IsActive)
                .FirstAsync(f => f.Id.ToString() == fragranceId);

            return new FragranceDetailsViewModel
            {
                Id = fragrance.Id.ToString(),
                Name = fragrance.Name,
                Category = fragrance.Category.Name,
                ImageUrl = fragrance.ImageUrl,
                Price = fragrance.Price,
                Description = fragrance.Description,
            };
        }


        //Accords
        public async Task UpdateFragranceAccordsAsync(string fragranceId, FragranceAccordsModel accords)
        {
            var fragrance = await dbContext.Fragrances
                .Include(f => f.FragrancesAccords)
                .FirstOrDefaultAsync(f => f.Id.ToString() == fragranceId);

            if (fragrance != null)
            {
                // Create a new FragranceAccords entity
                var newFragranceAccords = new FragranceAccords();

                // Create a new Accords entity and set its properties
                var newAccordsEntity = new Accords
                {
                    Woody = accords.Woody,
                    Citrus = accords.Citrus,
                    Spicy = accords.Spicy,
                    Aromatic = accords.Aromatic,
                    Floral = accords.Floral,
                    Fruity = accords.Fruity,
                    Green = accords.Green,
                    Herbal = accords.Herbal,
                    Musky = accords.Musky
                };

                // Assign the new Accords entity to the new FragranceAccords entity
                newFragranceAccords.Accords = newAccordsEntity;

                // Remove the existing FragranceAccords entity
                if (fragrance.FragrancesAccords.Any())
                {
                    var existingFragranceAccords = fragrance.FragrancesAccords.First();
                    dbContext.FragranceAccords.Remove(existingFragranceAccords);
                }

                // Add the new FragranceAccords entity to the Fragrance's collection
                fragrance.FragrancesAccords.Add(newFragranceAccords);

                // Save changes
                await dbContext.SaveChangesAsync();
            }
        }







        //new
        public async Task<FragranceAccordsModel> GetAccordsByFragranceIdAsync(string fragranceId)
        {
            var fragranceAccords = await dbContext.FragranceAccords
                .Include(fa => fa.Accords)
                .FirstOrDefaultAsync(fa => fa.FragranceId.ToString() == fragranceId);

            if (fragranceAccords == null)
            {
                // Initialize with default values and save it to the database
                fragranceAccords = new FragranceAccords
                {
                    FragranceId = Guid.Parse(fragranceId),
                    Accords = new Accords
                    {
                        Woody = 0,
                        Citrus = 0,
                        Spicy = 0,
                        Aromatic = 0,
                        Floral = 0,
                        Fruity = 0,
                        Green = 0,
                        Herbal = 0,
                        Musky = 0
                    }
                };

                await dbContext.FragranceAccords.AddAsync(fragranceAccords);
                await dbContext.SaveChangesAsync();
            }

            return new FragranceAccordsModel
            {
                FragranceId = fragranceId,
                Woody = fragranceAccords.Accords.Woody,
                Citrus = fragranceAccords.Accords.Citrus,
                Spicy = fragranceAccords.Accords.Spicy,
                Aromatic = fragranceAccords.Accords.Aromatic,
                Floral = fragranceAccords.Accords.Floral,
                Fruity = fragranceAccords.Accords.Fruity,
                Green = fragranceAccords.Accords.Green,
                Herbal = fragranceAccords.Accords.Herbal,
                Musky = fragranceAccords.Accords.Musky
            };
        }



    }
}
