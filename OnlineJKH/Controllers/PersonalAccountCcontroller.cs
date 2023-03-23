using Microsoft.AspNetCore.Mvc;
using OnlineJKH.BLL;
using OnlineJKH.DAL.Entities;
using OnlineJKH.Models.EditModel;

namespace OnlineJKH.Controllers
{
    public class PersonalAccountController : Controller
    {
        private DataManager dataManager;
        public PersonalAccountController(DataManager _dataManager)
        {
            dataManager = _dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.PersonalAccount.GetPersonalAccounts());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PersonalAccount personal)
        {
            if (ModelState.IsValid)
            {
                dataManager.PersonalAccount.Create(personal);
                return RedirectToAction("Index");
            }
            return View(personal);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var personal = dataManager.PersonalAccount.Get(id);
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
    }
}
