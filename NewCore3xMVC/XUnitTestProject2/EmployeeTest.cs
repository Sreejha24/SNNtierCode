using System;
using Xunit;
using NewCore3xMVC;
using NewCore3xMVC.Controllers;
using RepositoryPattern.Data;
using RepositoryPattern;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RepositoryPattern.Models;

namespace XUnitTestProject2
{
    public class EmployeeTest
    {
        // we follow 3 steps to test
        // 1. Arrage, 2. Act, 3. Assert

        RepositoryContext _context = null;
        IRepositoryWrapper _repositoryWrapper = null;
        EmployeesController _employeesController = null;
        public static IConfiguration _appSetting = null;

        public EmployeeTest()
        {
            // 1. Arrange            
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
            // 2. Act
            var iActionResult = await _employeesController.Index();

            var viewResult = iActionResult as ViewResult;

            var model = viewResult.Model as List<Employee>;

            // 3. Assert
            Assert.NotNull(viewResult);
            Assert.Equal(94, model.Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(0)]
        public async Task Details(int id)
        {
            // 2. Act
            var iactionResult = await _employeesController.Details(id);
            var result = iactionResult as ViewResult;

            // 3. Assert
            if (id == 0 || id == 2)
            {
                Assert.Null(result);
            }
            else
            {
                var model = result.Model as Employee;

                Assert.NotNull(iactionResult);
                Assert.Equal("Sheo", model.FullName);
            }
        }

        [Fact]
        public void Create()
        {
            // Act
            var actionResult = _employeesController.Create();
            var result = actionResult as ViewResult;
            // Assert
            Assert.NotNull(actionResult);
            Assert.Equal("Create", result.ViewName);
        }

    }
}
