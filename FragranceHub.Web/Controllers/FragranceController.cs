﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FragranceHub.Web.Controllers
{
    [Authorize]
    public class FragranceController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {

            return View();
        }
    }
}
