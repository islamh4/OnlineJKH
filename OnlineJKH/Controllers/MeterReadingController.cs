using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineJKH.BLL;
using OnlineJKH.DAL.Entities;

namespace OnlineJKH.Controllers
{
    public class MeterReadingController : Controller
    {
        private DataManager _dataManager;
        public MeterReadingController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(_dataManager.MeterReadingService.GetMeterReadings());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.PersAc = new SelectList(_dataManager.PersonalAccountService.GetPersonalAccounts().ToList(), "Id", "Number");
            return View();
        }
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.PersAc = new SelectList(_dataManager.PersonalAccountService.GetPersonalAccounts().ToList(), "Id", "Number");
            return View(_dataManager.MeterReadingService.Get(id));
        }
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
        public IActionResult Delete(int id)
        {
            _dataManager.MeterReadingService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
