using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Alachisoft.NCache.Config.Dom;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace NewCore3xMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                // logger.Debug("NLog Init main");
                CreateHostBuilder(args).Build().Run();
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    // START - NLog

                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Information);
                    logging.AddConsole();

                    //.UseNLog(); // important for Nlog
                    // END Nlog

                    // clear default logging providers
                    //logging.ClearProviders();

                    //// add built-in providers manually, as needed 
                    //logging.AddConsole();
                    //logging.AddDebug();
                    //logging.AddEventLog(); // Add Microsoft.Extensions.Logging.EventLog from nuget
                    //logging.AddEventSourceLogger();
                    // logging.AddTraceSource(sourceSwitchName);

                    // logging.ClearProviders();
                    // logging.SetMinimumLevel(LogLevel.Information);
                    //logging.AddEventLog(settings =>
                    //{
                    //    settings.SourceName = "Training2020";
                    //    settings.LogName = "Training";
                    //});
                    // logging.AddConsole();
                    // logging.AddEventLog();

                }).UseNLog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // webBuilder.UseKestrel(d => d.AddServerHeader = false); only when hosted on IIS
                    webBuilder.UseStartup<Startup>();
                });
        
    }


}
