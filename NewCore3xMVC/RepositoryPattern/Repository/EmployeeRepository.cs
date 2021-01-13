using RepositoryPattern.Data;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
