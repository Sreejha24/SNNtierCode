using Alachisoft.NCache.Common.Logger;
using Alachisoft.NCache.Config.Dom;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCore3xMVC.Filters
{
    public class MyActionFilter : IActionFilter
    {
        private Stopwatch _timer;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _timer.Stop();

            string elapsedTime = " <hr />Elapsed time: " + _timer.Elapsed.TotalMilliseconds;
            IActionResult actionResult = context.Result;
            ((ContentResult)actionResult).Content += elapsedTime;
            
            //context.HttpContext.Response.WriteAsync("After action executed.");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _timer = Stopwatch.StartNew();

            //context.HttpContext.Response.WriteAsync("Before action exeuted.");
        }
    }
}
