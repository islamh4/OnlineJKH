using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineJKH.BLL;
using OnlineJKH.DAL.Entities;
using OnlineJKH.Models.EditModel;
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
        public IActionResult Create()
        {
            ViewBag.User = new SelectList(UserViews(_dataManager.UserService.GetUsers()), "Id", "FIO");
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Create(PersonalAccount personal)
        {
            if (ModelState.IsValid)
            {
                _dataManager.PersonalAccountService.Create(personal);
                return RedirectToAction("Index");
            }
            ViewBag.User = new SelectList(UserViews(_dataManager.UserService.GetUsers()), "Id", "FIO");
            return View(personal);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.User = new SelectList(UserViews(_dataManager.UserService.GetUsers()), "Id", "FIO");
            return View(_dataManager.PersonalAccountService.Get(id));
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Edit(PersonalAccount personal)
        {
            if (ModelState.IsValid)
            {
                _dataManager.PersonalAccountService.Update(personal);
                return RedirectToAction("Index");
            }
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
