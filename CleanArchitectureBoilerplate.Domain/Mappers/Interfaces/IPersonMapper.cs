using CleanArchitectureBoilerplate.DataAccess.Models;
using CleanArchitectureBoilerplate.Models;
using CleanArchitectureBoilerplate.Models.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureBoilerplate.Domain.Mappers.Interfaces
{
    public interface IPersonMapper
    {
        PersonModel MapEntityToModel(Person person);

        List<PersonModel> MapEntityListToModelList(List<Person> personList);

        Person MapCreateRequestToEntity(PersonCreateRequest request);

        Person MapUpdateRequestToEntity(PersonUpdateRequest request);
    }
}
