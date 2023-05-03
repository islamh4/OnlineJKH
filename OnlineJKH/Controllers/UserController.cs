using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineJKH.BLL;
using OnlineJKH.DAL.Entities;
using System.Data;

namespace OnlineJKH.Controllers
{
    public class UserController : Controller
    {
        private DataManager _dataManager;
        public UserController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        [Authorize(Roles = "admin")]

        public IActionResult Index()
        {
            return View(_dataManager.UserService.GetUsers());
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Role = new SelectList(_dataManager.UserService.GetUsers().Select(m => m.Role).ToList(), "RoleId", "Role.Name");
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _dataManager.UserService.Create(user);
                return RedirectToAction("Index");
            }
            ViewBag.Role = new SelectList(_dataManager.UserService.GetUsers().ToList(), "RoleId", "Role.Name");
            return View(user);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Role = new SelectList(_dataManager.UserService.GetUsers().ToList(), "RoleId", "Role.Name");
            var user = _dataManager.UserService.Get(id);
            return View(user);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _dataManager.UserService.Update(user);
                return RedirectToAction("Index");
            }
            ViewBag.Role = new SelectList(_dataManager.UserService.GetUsers().ToList(), "RoleId", "Role.Name");
            return View(user);
        }
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            _dataManager.UserService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
