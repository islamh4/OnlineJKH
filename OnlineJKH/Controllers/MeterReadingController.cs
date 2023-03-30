using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineJKH.BLL;
using OnlineJKH.DAL.Entities;

namespace OnlineJKH.Controllers
{
    public class MeterReadingController : Controller
    {
        private DataManager dataManager;
        public MeterReadingController(DataManager _dataManager)
        {
            dataManager = _dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.MeterReading.GetMeterReading());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.PersAc = new SelectList(dataManager.PersonalAccount.GetPersonalAccounts().ToList(), "Id", "Number");
            return View();
        }
        [HttpPost]
        public IActionResult Create(MeterReading meter)
        {
            if (ModelState.IsValid)
            {
                dataManager.MeterReading.Create(meter);
                return RedirectToAction("Index");
            }
            ViewBag.PersAc = new SelectList(dataManager.PersonalAccount.GetPersonalAccounts().ToList(), "Id", "Number");
            return View(meter);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.PersAc = new SelectList(dataManager.PersonalAccount.GetPersonalAccounts().ToList(), "Id", "Number");
            var personal = dataManager.MeterReading.Get(id);
            return View(personal);
        }
        [HttpPost]
        public IActionResult Edit(MeterReading meter)
        {
            if (ModelState.IsValid)
            {
                dataManager.MeterReading.Update(meter);
                return RedirectToAction("Index");
            }
            ViewBag.PersAc = new SelectList(dataManager.PersonalAccount.GetPersonalAccounts().ToList(), "Id", "Number");
            return View(meter);
        }
        public IActionResult Delete(int id)
        {
            dataManager.MeterReading.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
