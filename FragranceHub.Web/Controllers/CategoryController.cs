using FragranceHub.Services.Data.Interfaces;
using FragranceHub.Web.ViewModels.Category;
using FragranceHub.Web.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace FragranceHub.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Men()
        {
            IEnumerable<FragranceByCategoryForm> viewModel =
                await this.categoryService.GetMenFragrancesAsync();

            return View(viewModel);
        }

        public async Task<IActionResult> Women()
        {
            IEnumerable<FragranceByCategoryForm> viewModel =
               await this.categoryService.GetWomenFragrancesAsync();

            return View(viewModel);

        }

        public async Task<IActionResult> Unisex()
        {
            IEnumerable<FragranceByCategoryForm> viewModel =
              await this.categoryService.GetUnisexFragrancesAsync();

            return View(viewModel);
        }
    }
}


