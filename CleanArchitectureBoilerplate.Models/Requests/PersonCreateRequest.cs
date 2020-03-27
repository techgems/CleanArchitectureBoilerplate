using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureBoilerplate.Models.Requests
{
    public class PersonCreateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CompanyId { get; set; }
    }
}
