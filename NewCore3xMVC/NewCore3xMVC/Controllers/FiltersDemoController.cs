using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewCore3xMVC.Filters;

namespace NewCore3xMVC.Controllers
{
    public class FiltersDemoController : Controller
    {
        [LogActionFilter]
        public ContentResult Index()
        {
            return Content("Hello");
        }

        public ContentResult ActionFilter()
        {
            return Content("Hello");
        }

        [TypeFilter(typeof(ElapsedTimeFilterAttribute))]
        // [ServiceFilter(typeof(ElapsedTimeFilterAttribute))]
        public IActionResult TimeElapsed()
        {
            return View();
        }
    }
}