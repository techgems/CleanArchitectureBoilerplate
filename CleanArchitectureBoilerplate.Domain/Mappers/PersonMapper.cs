using CleanArchitectureBoilerplate.DataAccess.Models;
using CleanArchitectureBoilerplate.Domain.Mappers.Interfaces;
using CleanArchitectureBoilerplate.Models;
using CleanArchitectureBoilerplate.Models.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureBoilerplate.Domain.Mappers
{
    public class PersonMapper : IPersonMapper
    {
        public PersonModel MapEntityToModel(Person person)
        {
            var model = new PersonModel
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                CompanyId = person.CompanyId,
                PhoneNumber = person.PhoneNumber
            };

            return model;
        }

        public List<PersonModel> MapEntityListToModelList(List<Person> personList)
        {
            var personModelList = new List<PersonModel>();

            foreach(var person in personList)
            {
                personModelList.Add(MapEntityToModel(person));
            }

            return personModelList;
        }

        public Person MapCreateRequestToEntity(PersonCreateRequest request)
        {
            var person = new Person
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                CompanyId = request.CompanyId,
            };

            return person;
        }

        public Person MapUpdateRequestToEntity(PersonUpdateRequest request)
        {
            var person = new Person
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                CompanyId = request.CompanyId
            };

            return person;
        }
    }
}
