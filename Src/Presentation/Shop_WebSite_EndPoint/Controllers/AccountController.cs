using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Users;
using Shop_WebSite_EndPoint.Models.User;

namespace Shop_WebSite_EndPoint.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _UserManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
                return View(register);
            User newUser = new User()
            {
                Email = register.Email,
                UserName = register.Email,
                FullName = register.FullName,
                PhoneNumber = register.PhoneNumber,
            };

            var result = _UserManager.CreateAsync(newUser, register.Password).Result;
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Profile));
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.Code, item.Description);
            }
            return View(register);
        }
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Login(string returnUrl = "/")
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl,
            });
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _UserManager.FindByNameAsync(model.Email).Result;
            if (user == null)
            {
                ModelState.AddModelError("", "کاربر یافت نشد");
                return View(model);
            }
            _signInManager.SignOutAsync();
            var result = _signInManager.PasswordSignInAsync(user, model.Password
                , model.IsPersistent, true).Result;

            if (result.Succeeded)
                return Redirect(model.ReturnUrl);

            if (result.RequiresTwoFactor)
            {
                //Todo
            }

            return View(model);
        }
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
