using Booking.BLL.ViewModels;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ActionResult Login(string returnUrl)
        {
            return View(new AccountLoginVM { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var result = await _signInManager.PasswordSignInAsync(user ?? new User(), model.Password, true, false);

                if (result.Succeeded)
                {
                    return LocalRedirect(model.ReturnUrl ?? "/");
                }

                ModelState.AddModelError("", "Invalid username or password");
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View(new AccountRegisterVM());
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterVM viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = viewModel.Email.Split('@')[0],
                    Email = viewModel.Email,
                };

                var result = await _userManager.CreateAsync(user, viewModel.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction(nameof(Login));
                }

                foreach (var identityError in result.Errors)
                {
                    ModelState.AddModelError("", identityError.Description);
                }
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return LocalRedirect("/");
        }
    }
}
