namespace FragranceHub.Web.Controllers
{
    using FragranceHub.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    using ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IFragranceService fragranceService;

        public HomeController(IFragranceService fragranceService)
        {
            this.fragranceService = fragranceService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<IndexViewModel> viewModel = await this.fragranceService.LastThreeFragrancesAsync();

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}