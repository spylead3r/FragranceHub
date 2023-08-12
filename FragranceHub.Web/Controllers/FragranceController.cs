﻿using FragranceHub.Data.Models;
using FragranceHub.Services.Data;
using FragranceHub.Services.Data.Interfaces;
using FragranceHub.Services.Data.Models.Fragrance;
using FragranceHub.Web.Infrastructure.Extensions;
using FragranceHub.Web.ViewModels.Fragrance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
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
                this.TempData[ErrorMessage] = "The fragrance is currently unavailable!";

                return this.RedirectToAction("All", "Fragrance");
            }

            try
            {
                FragranceDetailsViewModel viewModel = await this.fragranceService
                    .GetDetailsByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }

        public async Task<IActionResult> SetAccords()
        {
            FragranceFormModel formModel = new FragranceFormModel()
            {
                Categories = await this.categoryService.AllCategoriesAsync()
            };

            return this.View(formModel);
        }




        [Authorize(Roles = "Admin")] // Restrict access to admin users
        public async Task<IActionResult> SetAccords(string fragranceId)
        {
            var fragrance = await fragranceService.GetDetailsByIdAsync(fragranceId);
            return View(fragrance);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SetAccords(FragranceDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Update the fragrance accords in your service layer
                await fragranceService.UpdateFragranceAccordsAsync(model.Id, model.Accords);

                TempData[SuccessMessage] = "Accords updated successfully.";

                return RedirectToAction("Details", new { fragranceId = model.Id });
            }

            // If ModelState is not valid, return the view with the model to display validation errors
            return View(model);
        }


    }
}
