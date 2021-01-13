using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;

namespace NewCore3xMVC.Controllers
{
    public class AsynAwaitDemoController : Controller
    {
        private readonly RepositoryContext _context;

        public AsynAwaitDemoController(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public IActionResult GetData()
        {
            var data = _context.Employees.ToList();
            return View(data);
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Employees.ToListAsync();
            return View(data);
        }
    }
}