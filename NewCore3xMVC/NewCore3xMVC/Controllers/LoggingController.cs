using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NewCore3xMVC.Controllers
{
    public class LoggingController : Controller
    {
        private readonly ILogger<LoggingController> _logger;
        public LoggingController(ILogger<LoggingController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            // for NLog, check following
                    // program.cs, nlog.config
            _logger.LogDebug (1, "Index in debugging mode.");
            _logger.LogInformation("Index page called.");
            return View();
        }
    }
}
