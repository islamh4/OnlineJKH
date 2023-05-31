using Microsoft.AspNetCore.Mvc;
using OnlineJKH.BLL;
using OnlineJKH.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace OnlineJKH.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataManager _dataManager;
        public HomeController(ILogger<HomeController> logger, DataManager dataManager)
        {
            _logger = logger;
            _dataManager = dataManager;
        }
        [Authorize(Roles = "admin, user")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ExportExcel()
        {
            return new FileContentResult(_dataManager.ExportExcelService.ExportExcel(),
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = $"FileAdmin.xlsx"
            };
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}