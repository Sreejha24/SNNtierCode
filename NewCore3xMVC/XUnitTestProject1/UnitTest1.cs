using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCore3xMVC.Controllers;
using RepositoryPattern;
using RepositoryPattern.Data;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async Task TestList()
        {
            // Arrange
            var contextOptions = new DbContextOptionsBuilder().UseSqlServer("Server=D1DGQLH2\\SQLEXP2017;Database=DotNetCore;Trusted_Connection=True;MultipleActiveResultSets=true");
            RepositoryContext context = new RepositoryContext(contextOptions.Options);
            IRepositoryWrapper epositoryWrapper = null;

            EmployeesController employeesController = new EmployeesController(context, epositoryWrapper);

            // Act
            IActionResult result = await employeesController.Index();

            var viewResult = result as ViewResult;
            var model = viewResult.Model as List<Employee>;

            Assert.NotNull(result);
            Assert.Equal(94, model.Count);
            // Assert.Equal(94, result.);
        }
    }
}
