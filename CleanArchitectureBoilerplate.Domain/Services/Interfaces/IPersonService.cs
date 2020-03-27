using CleanArchitectureBoilerplate.Models;
using CleanArchitectureBoilerplate.Models.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureBoilerplate.Domain.Services.Interfaces
{
    public interface IPersonService
    {
        List<PersonModel> GetAll();

        PersonModel Create(PersonCreateRequest request);

        PersonModel Update(PersonUpdateRequest request);

        void Delete(int id);
    }
}
