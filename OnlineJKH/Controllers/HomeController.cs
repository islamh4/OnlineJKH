using Microsoft.AspNetCore.Mvc;
using OnlineJKH.BLL;
using OnlineJKH.DAL.Entities;
using OnlineJKH.Models;
using System.Diagnostics;

namespace OnlineJKH.Controllers
{
    public class HomeController : Controller
    {
        private DataManager dataManager;
        public HomeController(DataManager _dataManager)
        {
            dataManager = _dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.PersonalAccount.GetPersonalAccounts());
        }
        [HttpGet]
        public IActionResult Creat()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Creat(PersonalAccount personal)
        {
            if (ModelState.IsValid)
            {
                dataManager.PersonalAccount.Creat(personal);
                return RedirectToAction("Index");
            }
            return View(personal);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var personal = dataManager.PersonalAccount.UpdateId(id);
            return View(personal);
        }
        [HttpPost]
        public IActionResult Edit(PersonalAccount personal)
        {
            if (ModelState.IsValid)
            {
                dataManager.PersonalAccount.Update(personal);
                return RedirectToAction("Index");
            }
            return View(personal);
        }
        public IActionResult Delete(int id)
        {
            dataManager.PersonalAccount.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}