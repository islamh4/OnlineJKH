using Microsoft.AspNetCore.Mvc;
using OnlineJKH.BLL;
using OnlineJKH.DAL.Entities;

namespace OnlineJKH.Controllers
{
    public class UserController : Controller
    {
        private DataManager _dataManager;
        public UserController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(_dataManager.UserService.GetUsers());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _dataManager.UserService.Create(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _dataManager.UserService.Get(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _dataManager.UserService.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
        public IActionResult Delete(int id)
        {
            _dataManager.UserService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
