using FragranceHub.Data.Models;
using FragranceHub.Web.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace FragranceHub.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserStore<ApplicationUser> userStore;

        public UserController(SignInManager<ApplicationUser> signInManager,
                             UserManager<ApplicationUser> userManager,
                             IMemoryCache memoryCache)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;

           // this.memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Register(RegisterFormModel model)
        {
            if (!ModelState.IsValid) 
            { 
                return this.View(model);
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            await this.userManager.SetEmailAsync(user, model.Email);
            await this.userManager.SetUserNameAsync(user, model.Email);

            IdentityResult result = 
                await this.userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model.Email);
            }

            await this.signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");

        }
    }        
}
