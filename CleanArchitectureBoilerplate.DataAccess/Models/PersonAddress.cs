using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureBoilerplate.DataAccess.Models
{
    [Table("PersonAddress")]
    public class PersonAddress
    {
        public int Id { get; set; }
        public string FullAddress { get; set; }
        public string ZipCode { get; set; }
        public bool IsBilling { get; set; }
        public int PersonId { get; set; }

        //Navigation Properties
        [Computed]
        public Person Person { get; set; }
    }
}
