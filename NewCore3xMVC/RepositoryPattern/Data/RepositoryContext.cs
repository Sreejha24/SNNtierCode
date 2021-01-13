using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern.Data
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<People> People { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
