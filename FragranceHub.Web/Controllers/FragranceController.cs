using FragranceHub.Services.Data.Interfaces;
using FragranceHub.Services.Data.Models.Fragrance;
using FragranceHub.Web.ViewModels.Fragrance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace FragranceHub.Web.Controllers
{
    [Authorize]
    public class FragranceController : Controller
    {
        private readonly IFragranceService fragranceService;
        private readonly ICategoryService categoryService;
        public FragranceController(IFragranceService fragranceService, ICategoryService categoryService)
        {
            this.fragranceService = fragranceService;
            this.categoryService = categoryService;
        }



        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllFragrancesQueryModel queryModel)
        {
            AllFragrancesFilteredModel serviceModel = await fragranceService.AllFragrancesAsync(queryModel);

            queryModel.Fragrances = serviceModel.Fragrances;
            queryModel.TotalFragrances = serviceModel.TotalFragrancesCount;
            queryModel.Categories = await categoryService.AllCategoryNamesAsync();



            return this.View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            FragranceFormModel formModel = new FragranceFormModel()
            {
                Categories = await this.categoryService.AllCategoriesAsync()
            };

            return this.View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FragranceFormModel model)
        {
            bool categoryExists = await
                this.categoryService.ExistsByIdAsync(model.CategoryId);

            if (!categoryExists)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Selected category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoriesAsync();


                return this.View(model);
            }

            try
            {
                
               await this.fragranceService.CreateAsync(model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(String.Empty, "Unexpected error occured while trying to add fragrance!");
                model.Categories = await this.categoryService.AllCategoriesAsync();

                return this.View(model); 
            }

            return this.RedirectToAction("All", "Fragrance");
        }
    }
}
