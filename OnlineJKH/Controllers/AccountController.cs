using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OnlineJKH.BLL;
using OnlineJKH.DAL.Entities;
using OnlineJKH.Models.ViewModel;

namespace OnlineJKH.Controllers
{
    public class AccountController : Controller
    {
        private DataManager _dataManager;
        public AccountController(DataManager dataManager) 
        { 
            _dataManager = dataManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AccountViewModel model)
        {
            if(ModelState.IsValid)
            {
                Account account = new Account { Login = model.Login, Password = model.Password };
                var response = _dataManager.AccountService.Login(account);
                if (response == null) { ModelState.AddModelError("", "Пользователь не найден"); return View(model); }
                await HttpContext.SignInAsync(response);
                return Redirect("~/Home/Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
