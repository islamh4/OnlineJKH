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
        public IActionResult EditForm(int id = -1)
        {
            ViewBag.PersAc = new SelectList(_dataManager.PersonalAccountService.GetPersonalAccounts().ToList(), "Id", "Number");
            if(id == -1)
            {
                ViewBag.Button = "Добавить";
                return View();
            }
                

            ViewBag.Button = "Сохранить";
            ViewBag.NameView = "Изменение";
            return View(_dataManager.MeterReadingService.Get(id));
        }
        [Authorize(Roles = "admin, user")]
        [HttpPost]
        public ActionResult EditForm(MeterReading meter)
        {
            if (ModelState.IsValid)
            {
                if(meter.Id == 0)
                {
                    _dataManager.MeterReadingService.Create(meter);
                    return RedirectToAction("Index");
                }
                _dataManager.MeterReadingService.Update(meter);
                return RedirectToAction("Index");
                
            }
            if (meter.Id == 0)
            {
                ViewBag.Button = "Добавить";
                ViewBag.PersAc = new SelectList(_dataManager.PersonalAccountService.GetPersonalAccounts().ToList(), "Id", "Number");
                return View(meter);
            }
            ViewBag.Button = "Сохранить";
            ViewBag.NameView = "Изменение";
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
