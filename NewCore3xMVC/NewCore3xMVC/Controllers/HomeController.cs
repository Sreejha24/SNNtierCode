using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewCore3xMVC.Models;
using System.Text.Json;

namespace NewCore3xMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        public IActionResult Index(int? id)
        {
            if (id.HasValue)
            {
                if (TempData.ContainsKey("ID"))
                {
                    TempData.Remove("ID");
                }
                TempData.Add("ID", id.Value);
                return RedirectToAction("Privacy");
            }
            else
            {
                return View();
            }            
        }

        public IActionResult Privacy()
        {
            var id = TempData["ID"];
            ViewBag.ID = id;
            return View();
        }

        public IActionResult Tutorials()
        {
            return View();
        }

        public IActionResult Middleware()
        {
            return View();
        }

        public IActionResult TagHelper()
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
