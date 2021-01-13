using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Data;

namespace NewCore3xMVC.Controllers
{
    public class Viewbag : Controller
    {
        private readonly RepositoryContext _context;

        public ViewBag(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public IActionResult Index()
        {
           
            var employee = _context.Employees.ToList();

            ViewBag.CompanyName = "TollPlus India Ltd.";

            ViewBag.Employees = employee;
            ViewData["City"] = "Hyderabad";

            return View(data);
        }
    }
}