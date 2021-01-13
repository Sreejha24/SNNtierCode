using Alachisoft.NCache.Common.Logger;
using Alachisoft.NCache.Config.Dom;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NewCore3xMVC.Filters
{
    public class ElapsedTimeFilterAttribute : Attribute, IActionFilter
    {

        private Stopwatch _timer;
        readonly ILogger<ElapsedTimeFilterAttribute> _logger;

        public ElapsedTimeFilterAttribute(ILogger<ElapsedTimeFilterAttribute> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _timer.Stop();

            string elapsedTime = " <hr />Elapsed time: " + _timer.Elapsed.TotalMilliseconds;

            _logger.LogInformation(elapsedTime);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _timer = Stopwatch.StartNew();
        }
    }
}
