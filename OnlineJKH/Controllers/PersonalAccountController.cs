using Microsoft.AspNetCore.Mvc;
using OnlineJKH.BLL;
using OnlineJKH.DAL.Entities;
using OnlineJKH.Models.EditModel;

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
                _dataManager.PersonalAccountService.Create(personal);
                return RedirectToAction("Index");
            }
            return View(personal);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var personal = _dataManager.PersonalAccountService.Get(id);
            return View(personal);
        }
        [HttpPost]
        public IActionResult Edit(PersonalAccount personal)
        {
            if (ModelState.IsValid)
            {
                _dataManager.PersonalAccountService.Update(personal);
                return RedirectToAction("Index");
            }
            return View(personal);
        }
        public IActionResult Delete(int id)
        {
            _dataManager.PersonalAccountService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
