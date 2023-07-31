using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FragranceHub.Web.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        public IActionResult Mine()
        {
            return View();
        }
    }
}
