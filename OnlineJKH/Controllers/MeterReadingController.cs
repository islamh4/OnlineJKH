using Grpc.Net.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineJKH.BLL;
using OnlineJKH.DAL.EF;
using OnlineJKH.DAL.Entities;

namespace OnlineJKH.Controllers
{
    public class MeterReadingController : Controller
    {
        private DataManager _dataManager;
        private EFDBContext _dbContext;
        public MeterReadingController(DataManager dataManager, EFDBContext context)
        {
            _dataManager = dataManager;
            _dbContext = context;
        }
        [Authorize(Roles = "admin, user")]
        public IActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View(_dataManager.MeterReadingService.GetMeterReadings());
        }
        [Authorize(Roles = "admin, user")]
        [HttpGet]
        public IActionResult EditForm(int id = -1)
        {
            ViewBag.PersAc = new SelectList(_dataManager.PersonalAccountService.GetPersonalAccounts().ToList(), "Id", "Number");
            if (id == -1)
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
        public async Task<ActionResult> EditForm(MeterReading meter)
        {
            string replyMessage;
            if (ModelState.IsValid)
            {
                if (meter.Id == 0)
                {
                    PersonalAccount indicValue = _dbContext.PersonalAccounts.FirstOrDefault(m => m.Id == meter.PersonalAccountId);
                    using var channel = GrpcChannel.ForAddress("http://localhost:5016");
                    var client = new Greeter.GreeterClient(channel);
                    var reply = await client.SendingReceiptAsync(new Request { Number = indicValue.Number, IndicationValue = meter.IndicationValue.ToString() });
                    _dataManager.MeterReadingService.Create(meter);
                    return RedirectToAction("Index", "MeterReading", new { message = reply.Message });
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