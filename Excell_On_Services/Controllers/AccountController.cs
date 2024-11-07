//using Excell_On_Services.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace Excell_On_Services.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly UserManager<SD.Role_Employee> _userManager;
//        private readonly SignInManager<SD.Role_Employee> _signInManager;

//        public AccountController(UserManager<Role_Employee> userManager, SignInManager<Role_Employee> signInManager)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//        }

//        [HttpGet]
//        public IActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Login(IdentityUserLogin model)
//        {
//            if (ModelState.IsValid)
//            {
//                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.ConfirmPassword, false);
//                if (result.Succeeded)
//                {
//                    var user = await _userManager.FindByEmailAsync(model.Email);
//                    if (user.Role == SD.Role_Admin || user.Role == SD.Role_Employee)
//                    {
//                        return RedirectToAction("Index", "Dashboard");
//                    }
//                    else if (user.Role == SD.Role_Customer)
//                    {
//                        return RedirectToAction("Index", "Home");
//                    }
//                }
//                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
//            }
//            return View(model);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Logout()
//        {
//            await _signInManager.SignOutAsync();
//            return RedirectToAction("Index", "Home");
//        }
//    }

//}
