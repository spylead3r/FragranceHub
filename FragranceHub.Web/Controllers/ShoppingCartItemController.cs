using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FragranceHub.Web.Controllers
{
    [Authorize]
    public class ShoppingCartItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
