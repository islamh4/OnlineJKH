using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineJKH.BLL;
using OnlineJKH.DAL.Entities;
using System.Data;

namespace OnlineJKH.Controllers
{
    public class MeterReadingController : Controller
    {
        private DataManager _dataManager;
        public MeterReadingController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        [Authorize(Roles = "admin, user")]
        public IActionResult Index()
        {
            return View(_dataManager.MeterReadingService.GetMeterReadings());
        }
        [Authorize(Roles = "admin, user")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.PersAc = new SelectList(_dataManager.PersonalAccountService.GetPersonalAccounts().ToList(), "Id", "Number");
            return View();
        }
        [Authorize(Roles = "admin, user")]
        [HttpPost]
        public IActionResult Create(MeterReading meter)
        {
            if (ModelState.IsValid)
            {
                _dataManager.MeterReadingService.Create(meter);
                return RedirectToAction("Index");
            }
            ViewBag.PersAc = new SelectList(_dataManager.PersonalAccountService.GetPersonalAccounts().ToList(), "Id", "Number");
            return View(meter);
        }
        [Authorize(Roles = "admin, user")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.PersAc = new SelectList(_dataManager.PersonalAccountService.GetPersonalAccounts().ToList(), "Id", "Number");
            return View(_dataManager.MeterReadingService.Get(id));
        }
        [Authorize(Roles = "admin, user")]
        [HttpPost]
        public IActionResult Edit(MeterReading meter)
        {
            if (ModelState.IsValid)
            {
                _dataManager.MeterReadingService.Update(meter);
                return RedirectToAction("Index");
            }
            ViewBag.PersAc = new SelectList(_dataManager.PersonalAccountService.GetPersonalAccounts().ToList(), "Id", "Number");
            return View(meter);
        }
        [Authorize(Roles = "admin, user")]
        public IActionResult Delete(int id)
        {
            _dataManager.MeterReadingService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
