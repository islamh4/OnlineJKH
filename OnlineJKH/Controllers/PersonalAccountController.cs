using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineJKH.BLL;
using OnlineJKH.DAL.Entities;
using OnlineJKH.Models.ViewModel;
using System.Data;

namespace OnlineJKH.Controllers
{
    public class PersonalAccountController : Controller
    {
        private DataManager _dataManager;
        public PersonalAccountController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View(_dataManager.PersonalAccountService.GetPersonalAccounts());
        }
        public IEnumerable<UserViewModel> UserViews(IEnumerable<User> user)
        {
            return _dataManager.UserService.GetUsers().Select(m => new UserViewModel { 
                Id = m.Id , 
                FIO = (m.Surname+" "+m.Name+" "+m.Patronymic).ToString()
            }).ToList();
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult EditForm(int id = -1)
        {
            ViewBag.User = new SelectList(UserViews(_dataManager.UserService.GetUsers()), "Id", "FIO");
            if (id == -1)
            {
                ViewBag.Button = "Добавить";
                return View();
            }
            ViewBag.Button = "Сохранить";
            ViewBag.NameView = "Изменение";
            return View(_dataManager.PersonalAccountService.Get(id));
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditForm(PersonalAccount personal)
        {
            if (ModelState.IsValid)
            {
                if (personal.Id == 0)
                {
                    _dataManager.PersonalAccountService.Create(personal);
                    return RedirectToAction("Index");
                }
                _dataManager.PersonalAccountService.Update(personal);
                return RedirectToAction("Index");

            }
            if (personal.Id == 0)
            {
                ViewBag.Button = "Добавить";
                ViewBag.User = new SelectList(UserViews(_dataManager.UserService.GetUsers()), "Id", "FIO");
                return View(personal);
            }
            ViewBag.Button = "Сохранить";
            ViewBag.NameView = "Изменение";
            ViewBag.User = new SelectList(UserViews(_dataManager.UserService.GetUsers()), "Id", "FIO");
            return View(personal);
        }
        
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            _dataManager.PersonalAccountService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
