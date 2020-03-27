using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureBoilerplate.DataAccess.Utils
{
    public class PaginatedList<T> where T : class
    {
        public List<T> EntityList { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { 
            get { return PageSize / TotalCount; } 
        }
    }
}
