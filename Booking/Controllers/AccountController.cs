using Booking.BLL.Contracts;
using Booking.BLL.ViewModels;
using Booking.DAL.Models;
using Booking.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepositories _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(IRepositories db, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _db = db;
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
                var result = await _signInManager.PasswordSignInAsync(user ?? new IdentityUser(), model.Password, false, false);

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
                IdentityUser user;
                if (viewModel.Role == "Hoster")
                {
                    user = new Hoster
                    {
                        UserName = viewModel.Email.Split('@')[0],
                        Email = viewModel.Email,
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName
                    };
                }
                else
                {
                    user = new Explorer
                    {
                        UserName = viewModel.Email.Split('@')[0],
                        Email = viewModel.Email,
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName
                    };
                }

                var result = await _userManager.CreateAsync(user, viewModel.Password);
                if (result.Succeeded)
                {
                    if (viewModel.Role == "Hoster")
                    {
                        await _userManager.AddToRoleAsync(user, "hoster");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "explorer");
                    }

                    await _signInManager.SignInAsync(user, true);
                    return LocalRedirect("/");
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

        public ActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> Complain(AccountComplainVM input)
        {
            if (!ModelState.IsValid)
            {
                return LocalRedirect($"/HosterArea/Rent/Details/{input.RentId}");
            }

            Complaint c = new Complaint();
            c.ExplorerId = input.Id.ToString();
            c.Text = input.Text;
            c.HosterId = User.GetUserId();
            c.RentId = input.RentId;

            await _db.Complaints.Add(c);

            return LocalRedirect($"/HosterArea/Rent/Details/{input.RentId}");
        }
    }
}
