using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineJKH.BLL;
using OnlineJKH.DAL.Entities;
using System.Data;

namespace OnlineJKH.Controllers
{
    public class ReceiptController : Controller
    {
        private DataManager _dataManager;
        public ReceiptController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        [Authorize(Roles = "admin, user")]
        public IActionResult Index()
        {
            return View(_dataManager.ReceiptService.GetReceipts());
        }
        [Authorize(Roles = "admin, user")]
        [HttpGet]
        public IActionResult EditForm(int id = -1)
        {
            ViewBag.MetRead = new SelectList(_dataManager.MeterReadingService.GetMeterReadings().ToList(), "Id", "IndicationValue");
            if (id == -1)
            {
                ViewBag.Button = "Добавить";
                return View();
            }

            ViewBag.Button = "Сохранить";
            ViewBag.NameView = "Изменение";
            return View(_dataManager.ReceiptService.Get(id));
        }
        [Authorize(Roles = "admin, user")]
        [HttpPost]
        public ActionResult EditForm(Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                if (receipt.Id == 0)
                {
                    _dataManager.ReceiptService.Create(receipt);
                    return RedirectToAction("Index");
                }
                _dataManager.ReceiptService.Update(receipt);
                return RedirectToAction("Index");

            }
            if (receipt.Id == 0)
            {
                ViewBag.Button = "Добавить";
                ViewBag.MetRead = new SelectList(_dataManager.MeterReadingService.GetMeterReadings().ToList(), "Id", "IndicationValue");
                return View(receipt);
            }
            ViewBag.Button = "Сохранить";
            ViewBag.NameView = "Изменение";
            ViewBag.MetRead = new SelectList(_dataManager.MeterReadingService.GetMeterReadings().ToList(), "Id", "IndicationValue");
            return View(receipt);
        }
        [Authorize(Roles = "admin, user")]
        public IActionResult Delete(int id)
        {
            _dataManager.ReceiptService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
