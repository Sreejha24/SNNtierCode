using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Data;

namespace NewCore3xMVC.Controllers
{
    public class ViewBagViewDataController : Controller
    {
        private readonly RepositoryContext _context;

        public ViewBagViewDataController(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public IActionResult Index()
        {
            var data = _context.People.ToList();
            var employee = _context.Employees.ToList();

            ViewBag.CompanyName = "TollPlus India Ltd.";

            ViewBag.Employees = employee;
            ViewData["City"] = "Hyderabad";

            return View(data);
        }
    }
}