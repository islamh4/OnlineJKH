using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineJKH.BLL;
using OnlineJKH.DAL.Entities;

namespace OnlineJKH.Controllers
{
    public class ReceiptController : Controller
    {
        private DataManager dataManager;
        public ReceiptController(DataManager _dataManager)
        {
            dataManager = _dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.Receipt.GetReceipt());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MetRead = new SelectList(dataManager.MeterReading.GetMeterReading().ToList(), "Id", "IndicationValue");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                dataManager.Receipt.Create(receipt);
                return RedirectToAction("Index");
            }
            ViewBag.MetRead = new SelectList(dataManager.MeterReading.GetMeterReading().ToList(), "Id", "IndicationValue");
            return View(receipt);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.MetRead = new SelectList(dataManager.MeterReading.GetMeterReading().ToList(), "Id", "IndicationValue");
            var receipt = dataManager.Receipt.Get(id);
            return View(receipt);
        }
        [HttpPost]
        public IActionResult Edit(Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                dataManager.Receipt.Update(receipt);
                return RedirectToAction("Index");
            }
            ViewBag.MeterRead = new SelectList(dataManager.MeterReading.GetMeterReading().ToList(), "Id", "IndicationValue");
            return View(receipt);
        }
        public IActionResult Delete(int id)
        {
            dataManager.Receipt.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
