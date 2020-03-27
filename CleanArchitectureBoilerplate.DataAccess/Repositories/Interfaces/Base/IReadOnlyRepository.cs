using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitectureBoilerplate.DataAccess.Utils;

namespace CleanArchitectureBoilerplate.DataAccess.Repositories.Interfaces.Base
{
    public interface IReadOnlyRepository<T> where T : class
    {
        public List<T> GetAll();
        public PaginatedList<T> GetPaginated(int page, int pageSize);
        public T GetById(int id);
    }
}
