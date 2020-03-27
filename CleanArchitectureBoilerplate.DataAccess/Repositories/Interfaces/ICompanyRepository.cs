using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitectureBoilerplate.DataAccess.Repositories.Interfaces.Base;
using CleanArchitectureBoilerplate.DataAccess.Models;

namespace CleanArchitectureBoilerplate.DataAccess.Repositories.Interfaces
{
    public interface ICompanyRepository : IFullRepository<Company>
    {
    }
}
