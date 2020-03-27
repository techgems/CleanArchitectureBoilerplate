using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureBoilerplate.DataAccess.Models
{
    [Table("Company")]
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        //Navigation Properties
        [Computed]
        public List<Person> Persons { get; set; }
    }
}
