using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineJKH.BLL;
using OnlineJKH.DAL.Entities;

namespace OnlineJKH.Controllers
{
    public class ReceiptController : Controller
    {
        private DataManager _dataManager;
        public ReceiptController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(_dataManager.ReceiptService.GetReceipts());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MetRead = new SelectList(_dataManager.MeterReadingService.GetMeterReadings().ToList(), "Id", "IndicationValue");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                _dataManager.ReceiptService.Create(receipt);
                return RedirectToAction("Index");
            }
            ViewBag.MetRead = new SelectList(_dataManager.MeterReadingService.GetMeterReadings().ToList(), "Id", "IndicationValue");
            return View(receipt);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.MetRead = new SelectList(_dataManager.MeterReadingService.GetMeterReadings().ToList(), "Id", "IndicationValue");
            var receipt = _dataManager.ReceiptService.Get(id);
            return View(receipt);
        }
        [HttpPost]
        public IActionResult Edit(Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                _dataManager.ReceiptService.Update(receipt);
                return RedirectToAction("Index");
            }
            ViewBag.MeterRead = new SelectList(_dataManager.MeterReadingService.GetMeterReadings().ToList(), "Id", "IndicationValue");
            return View(receipt);
        }
        public IActionResult Delete(int id)
        {
            _dataManager.ReceiptService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
