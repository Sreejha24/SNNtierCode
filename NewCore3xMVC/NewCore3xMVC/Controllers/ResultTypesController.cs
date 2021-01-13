using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Hosting.Internal;
using NewCore3xMVC.Data;
using RepositoryPattern.Data;
using RepositoryPattern.Models;

namespace NewCore3xMVC.Controllers
{
    public class ResultTypesController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly RepositoryContext _context;

        public ResultTypesController(RepositoryContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NotFound(int? id)
        {
            if (id.HasValue)
            {
                return View();
            }
            else
            {
                return Redirect("https://www.tollplus.com");
                return NotFound();
            }
        }

        public ContentResult Content()
        {
            return Content("This is my content.");
        }

        public JsonResult Json()
        {
            var employees = _context.Employees.Where(d=>d.FullName.StartsWith("s")).ToList();
            
            return Json(employees);
        }

        public IActionResult File()
        {
            string path = _webHostEnvironment.ContentRootPath;
            string fullPath = Path.Combine(path, "appsettings.json");
            var content = System.IO.File.ReadAllBytes(fullPath);
            return File(content, "application/json");
        }
    }
}