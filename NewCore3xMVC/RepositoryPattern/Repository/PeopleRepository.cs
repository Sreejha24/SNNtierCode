using RepositoryPattern.Data;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern.Repository
{
    public class PeopleRepository : RepositoryBase<People>, IPeopleRepository
    {
        public PeopleRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {

        }
    }
}
