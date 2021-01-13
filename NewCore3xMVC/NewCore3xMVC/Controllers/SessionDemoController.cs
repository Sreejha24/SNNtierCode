using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NewCore3xMVC.Controllers
{
    public class SessionDemoController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("Name", "Ram");
            
            var name = HttpContext.Session.GetString("Name");

            //HttpContext.Response.Cookies.Append("Name", "Shyam");

            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddSeconds(4)
            };
            HttpContext.Response.Cookies.Append("Address", "Hitech City, Hyderabad", options);

            return View();
        }

        public IActionResult Get()
        {
            string address = string.Empty;
            HttpContext.Request.Cookies.TryGetValue("Address", out address);
            return View();
        }
    }

}