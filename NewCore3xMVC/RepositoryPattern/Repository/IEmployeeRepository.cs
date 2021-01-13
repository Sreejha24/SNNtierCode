using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern.Repository
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
    }
}
