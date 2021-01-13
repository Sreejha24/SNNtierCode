using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using NewCore3xMVC.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.SqlServer.Update.Internal;
using Microsoft.CodeAnalysis.Options;
using RepositoryPattern;
using RepositoryPattern.Data;
using Microsoft.Extensions.Options;
using NewCore3xMVC.DependencyInjection;
using NewCore3xMVC.Middlewares;
using log4net.Repository.Hierarchy;
using Alachisoft.NCache.Common.Logger;
using NewCore3xMVC.Filters;

namespace NewCore3xMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // START - response caching

            //services.AddResponseCaching();

            // END - response caching

            // START - Inject service

            services.AddSingleton<IAgeCalculator, AgeCalculator>();
            // services.AddScoped<IAgeCalculator, AgeCalculator>();
            // END - Inject service

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            //services.AddScoped(typeof(ElapsedTimeFilterAttribute));

            services.AddControllersWithViews();

            services.AddDbContext<NewCore3xMVCContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("NewCore3xMVCContext")));

            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("NewCore3xMVCContext")));

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost";
                options.InstanceName = "SampleInstance";
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(50);
            });

            services.AddMvc(options =>
            {
                // options.Filters.Add(new MyActionFilter());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                // if this is on, it shows error page that is useful for developer
                // browser - http://localhost:55566/ErrorHandling
                app.UseDeveloperExceptionPage();

                // START - custom exception response.
                //app.UseExceptionHandler(err =>
                //{
                //    err.Run(async context =>
                //    {
                //        await context.Response.WriteAsync("<b>Sorry, error occured, coming from startup</b>");
                //    });
                //});
                // END - custom exception response.
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStatusCodePages();


            // START - middleware
            // when using app.Use, we have to pass the handle to the next middle ware
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("First middle ware.");
            //    await next();
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Second middle ware.");
            //    await next();
            //});

            //// custom middleware | Check Middlewares folder
            // app.UseMyCustomMiddleware();

            //// when usingn app.Run, that is the final middle ware to run
            //app.Run(async (context) =>
            //    {
            //        await context.Response.WriteAsync("Third and last middleware.");
            //    });

            //app.Use(async (context, next) =>
            //{

            //    if (context.Request.Path.Equals("/dotnetfunda"))
            //    {
            //        context.Response.Redirect("http://www.dotnetfunda.com");
            //        return;
            //    }
            //    await next();
            //});
            // END - middleware


            // START - response caching

            // app.UseResponseCaching();

            //app.Use(async (context, next) =>
            //{
            //    context.Response.GetTypedHeaders().CacheControl =
            //                new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
            //                {
            //                    Public = true,
            //                    MaxAge = TimeSpan.FromSeconds(300)
            //                };

            //    context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] = new string[] { "Accept-Encoding" };

            //    await next();
            //});

            // END - response caching

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapGet("/Hello", async context =>
                {
                    await context.Response.WriteAsync("Hello .NET Core MVC");

                    //context.Response.Redirect("https://www.dotnetfunda.com");
                });

                endpoints.MapControllerRoute(
                    name: "ConstraintTest",
                    pattern: "/Default/{id:int}/{username:minlength(4)}",
                    defaults: new { controller = "Default", action = "Index" }
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Privacy",
                    pattern: "/Privacy",
                    defaults: new { controller = "Home", action = "Privacy" }
                    );

            });



        }
    }
}
