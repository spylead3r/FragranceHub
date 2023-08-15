namespace FragranceHub.Web.Controllers
{
    using FragranceHub.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    using ViewModels.Home;

    using static FragranceHub.Common.GeneralAppConstants;

    public class HomeController : Controller
    {
        private readonly IFragranceService fragranceService;

        public HomeController(IFragranceService fragranceService)
        {
            this.fragranceService = fragranceService;
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(AdminRoleName))
            {
                return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}