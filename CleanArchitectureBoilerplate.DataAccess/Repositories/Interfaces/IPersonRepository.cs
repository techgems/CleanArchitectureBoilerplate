using System;
using System.Collections.Generic;
using CleanArchitectureBoilerplate.DataAccess.Repositories.Interfaces.Base;
using CleanArchitectureBoilerplate.DataAccess.Models;

namespace CleanArchitectureBoilerplate.DataAccess.Repositories.Interfaces
{
    public interface IPersonRepository : IFullRepository<Person>
    {
        public List<PersonAddress> GetPersonAdresses(int personId);

        public Person GetPersonWithAddresses(int personId);

        public bool IsEmailUnique(string emailAddress);
    }
}
