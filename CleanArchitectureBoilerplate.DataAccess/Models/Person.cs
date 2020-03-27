using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureBoilerplate.DataAccess.Models
{
    [Table("Person")]
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CompanyId { get; set; }

        //Navigation Properties
        [Computed]
        public List<PersonAddress> Adresses { get; set; }
        [Computed]
        public Company Company { get; set; }
    }
}
