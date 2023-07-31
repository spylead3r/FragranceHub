using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FragranceHub.Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        public IActionResult Mine()
        {
            return View();
        }
    }
}
