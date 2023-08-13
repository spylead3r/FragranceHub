using FragranceHub.Data.Models;
using FragranceHub.Services.Data;
using FragranceHub.Services.Data.Interfaces;
using FragranceHub.Services.Data.Models.Fragrance;
using FragranceHub.Web.Infrastructure.Extensions;
using FragranceHub.Web.ViewModels.Fragrance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using static FragranceHub.Common.NotificationMessagesConstants;

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

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool fragranceExists = await fragranceService
                .ExistsByIdAsync(id);

            if (!fragranceExists)
            {

                TempData[ErrorMessage] = "The fragrance is currently unavailable!";
                return this.NotFound();
            }



            try
            {
                FragranceFormModel formModel = await fragranceService
                    .GetFragranceForEditByIdAsync(id);
                formModel.Categories = await categoryService.AllCategoriesAsync();

                return View(formModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, FragranceFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.AllCategoriesAsync();

                return View(model);
            }

            bool fragranceExists = await fragranceService
                .ExistsByIdAsync(id);

            if (!fragranceExists)
            {

                return this.NotFound();
            }



            try
            {
                await fragranceService.EditFragranceByIdAndFormModelAsync(id, model);
                return RedirectToAction("All", "Fragrance");

            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty,
                    "Unexpected error occurred while trying to update the fragrance.");
                model.Categories = await categoryService.AllCategoriesAsync();

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool houseExists = await fragranceService
                .ExistsByIdAsync(id);

            if (!houseExists)
            {
                return this.NotFound();
            }


            try
            {
                FragrancePreDeleteViewModel viewModel =
                    await fragranceService.GetFragranceForDeleteByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }


        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id, FragrancePreDeleteViewModel model)
        {
            bool houseExists = await fragranceService
                .ExistsByIdAsync(id);


            if (!houseExists)
            {
                return this.NotFound();

            }


            try
            {
                await fragranceService.DeleteFragranceByIdAsync(id);

                return RedirectToAction("All", "Fragrance");
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool fragranceExist = await this.fragranceService
                .ExistsByIdAsync(id);

            if (!fragranceExist)
            {
                this.TempData[SuccessMessage] = "The fragrance is currently unavailable!";

                return this.RedirectToAction("All", "Fragrance");
            }

            try
            {
                FragranceDetailsViewModel viewModel = await this.fragranceService
                    .GetDetailsByIdAsync(id);

                var accords = await fragranceService.GetAccordsByFragranceIdAsync(id);

                viewModel.Accords = accords;

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }


        //Accords
        [HttpGet]
        public async Task<IActionResult> EditAccords(string fragranceId)
        {
            bool fragranceExist = await fragranceService.ExistsByIdAsync(fragranceId);

            if (!fragranceExist)
            {
                TempData[SuccessMessage] = "The fragrances is set!";
                return RedirectToAction("All", "Fragrance");
            }

            // Get the accords for the fragrance
            var accordsModel = await fragranceService.GetAccordsByFragranceIdAsync(fragranceId);

            // Pass the accords model to the view
            return View(accordsModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAccords(FragranceAccordsModel accordsModel)
        {
            if (ModelState.IsValid)
            {
                // Update the accords for the fragrance
                await fragranceService.UpdateFragranceAccordsAsync(accordsModel.FragranceId, accordsModel);

                // Redirect to the fragrance details page or perform other actions
                return RedirectToAction("Details", new { id = accordsModel.FragranceId });
            }

            // If ModelState is not valid, handle validation errors
            return View("EditAccords", accordsModel);
        }


        [HttpPost]
        public async Task<IActionResult> UploadAccords(FragranceAccordsModel accordsModel)
        {
            if (ModelState.IsValid)
            {
                // Update the accords for the fragrance
                await fragranceService.UpdateFragranceAccordsAsync(accordsModel.FragranceId, accordsModel);

                // Redirect to the fragrance details page or perform other actions
                return RedirectToAction("Details", new { id = accordsModel.FragranceId });
            }

            // If ModelState is not valid, handle validation errors
            return View("UploadAccords", accordsModel);
        }


        [HttpPost]
        public async Task<IActionResult> EditAccords(FragranceAccordsModel accordsModel)
        {
            if (ModelState.IsValid)
            {
                // Update the accords for the fragrance
                await fragranceService.UpdateFragranceAccordsAsync(accordsModel.FragranceId, accordsModel);

                // Fetch the updated accords
                var updatedAccords = await fragranceService.GetAccordsByFragranceIdAsync(accordsModel.FragranceId);

                // Update the Accords property of the FragranceDetailsViewModel
                var detailsViewModel = new FragranceDetailsViewModel
                {
                    // Initialize other properties here
                    Accords = updatedAccords
                };

                return RedirectToAction("Details", detailsViewModel); // Pass the updated view model
            }

            // If ModelState is not valid, handle validation errors
            return View("EditAccords", accordsModel);
        }





    }
}
