using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineJKH.BLL;
using OnlineJKH.DAL.Entities;
using OnlineJKH.Models.EditModel;
using OnlineJKH.Models.ViewModel;

namespace OnlineJKH.Controllers
{
    public class PersonalAccountController : Controller
    {
        private DataManager _dataManager;
        public PersonalAccountController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(_dataManager.PersonalAccountService.GetPersonalAccounts());
        }
        public IEnumerable<UserViewModel> UserViews(IEnumerable<User> user)
        {
            List<UserViewModel> users = new List<UserViewModel>();
            foreach (var item in _dataManager.UserService.GetUsers().ToList())
            {
                UserViewModel us = new UserViewModel();
                us.Id = item.Id;
                us.FIO = (item.Surname + " " + item.Name + " " + item.Patronymic).ToString();
                users.Add(us);
            }
            return users;
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.User = new SelectList(UserViews(_dataManager.UserService.GetUsers().ToList()), "Id", "FIO");
            return View();
        }
        [HttpPost]
        public IActionResult Create(PersonalAccount personal)
        {
            if (ModelState.IsValid)
            {
                _dataManager.PersonalAccountService.Create(personal);
                return RedirectToAction("Index");
            }
            ViewBag.User = new SelectList(UserViews(_dataManager.UserService.GetUsers().ToList()), "Id", "FIO");
            return View(personal);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.User = new SelectList(UserViews(_dataManager.UserService.GetUsers().ToList()), "Id", "FIO");
            return View(_dataManager.PersonalAccountService.Get(id));
        }
        [HttpPost]
        public IActionResult Edit(PersonalAccount personal)
        {
            if (ModelState.IsValid)
            {
                _dataManager.PersonalAccountService.Update(personal);
                return RedirectToAction("Index");
            }
            ViewBag.User = new SelectList(UserViews(_dataManager.UserService.GetUsers().ToList()), "Id", "FIO");
            return View(personal);
        }
        public IActionResult Delete(int id)
        {
            _dataManager.PersonalAccountService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
