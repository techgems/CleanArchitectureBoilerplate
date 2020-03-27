using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitectureBoilerplate.DataAccess.Utils;

namespace CleanArchitectureBoilerplate.DataAccess.Repositories.Interfaces.Base
{
    public interface IFullRepository<T> where T : class
    {
        public List<T> GetAll();
        public PaginatedList<T> GetPaginated(int page, int pageSize);
        public T GetById(int id);
        public T Create(T entity);
        public T Update(T entity);
        public void Delete(int id);
    }
}
