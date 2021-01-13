using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NewCore3xMVC.Controllers
{
    public class ErrorHandlingController : Controller
    {
        private readonly ILogger<ErrorHandlingController> _logger;
        public ErrorHandlingController(ILogger<ErrorHandlingController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                var z = 0;
                return Content((1 / z).ToString());
            }
            catch (Exception ce)
            {
                _logger.LogError("Error occured. " + ce.ToString());
                throw;
            }
            return View();
        }
    }
}