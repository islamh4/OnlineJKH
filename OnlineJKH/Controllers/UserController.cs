using Microsoft.AspNetCore.Mvc;
using OnlineJKH.BLL;
using OnlineJKH.DAL.Entities;

namespace OnlineJKH.Controllers
{
    public class UserController : Controller
    {
        private DataManager dataManager;
        public UserController(DataManager _dataManager)
        {
            dataManager = _dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.User.GetUser());
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
                dataManager.User.Create(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = dataManager.User.Get(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                dataManager.User.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
        public IActionResult Delete(int id)
        {
            dataManager.User.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
