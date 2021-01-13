using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewCore3xMVC.Controllers;
using RepositoryPattern;
using RepositoryPattern.Data;
using RepositoryPattern.Models;
using RepositoryPattern.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace NewCore3xTestxUnit
{
    public class EmployeeTest
    {
        RepositoryContext _context = null;
        IRepositoryWrapper _repositoryWrapper = null;
        EmployeesController _employeesController = null;
        public static IConfiguration _appSetting = null;

        public EmployeeTest()
        {
            // Arrange            
            _appSetting = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
            var connStr = _appSetting.GetConnectionString("NewCore3xMVCContext");
            var contextOptions = new DbContextOptionsBuilder().UseSqlServer(connStr);
            _context = new RepositoryContext(contextOptions.Options);
            _repositoryWrapper = new RepositoryWrapper(_context);
            _employeesController = new EmployeesController(_context, _repositoryWrapper);

        }

        [Fact]
        public async Task Index()
        {
            // Act
            IActionResult result = await _employeesController.Index();

            var viewResult = result as ViewResult;
            var model = viewResult.Model as List<Employee>;

            Assert.NotNull(result);
            Assert.Equal(94, model.Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        public async Task Details(int id)
        {
            // Act
            IActionResult result = await _employeesController.Details(id);
            var viewResult = result as ViewResult;

            // Assert
            if (id == 0)
            {
                Assert.Null(viewResult);
            }
            else
            {
                Assert.NotNull(viewResult);
                var model = viewResult.Model as Employee;
                Assert.IsType<Employee>(model);
                Assert.Equal("Sheo", model.FullName);
            }
        }


    }
}
