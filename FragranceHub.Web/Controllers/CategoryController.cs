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
        public async Task<IActionResult> Men()
        {
            IEnumerable<FragranceByCategoryForm> viewModel =
                await this.categoryService.GetMenFragrances();

            return View(viewModel);
        }

        public async Task<IActionResult> Women()
        {
            IEnumerable<FragranceByCategoryForm> viewModel =
               await this.categoryService.GetWomenFragrances();

            return View(viewModel);

        }

        public async Task<IActionResult> Unisex()
        {
            IEnumerable<FragranceByCategoryForm> viewModel =
              await this.categoryService.GetUnisexFragrances();

            return View(viewModel);
        }
    }
}


