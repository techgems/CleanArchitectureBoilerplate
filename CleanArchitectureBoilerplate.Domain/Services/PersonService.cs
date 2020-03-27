using CleanArchitectureBoilerplate.DataAccess.Repositories.Interfaces;
using CleanArchitectureBoilerplate.Domain.Mappers.Interfaces;
using CleanArchitectureBoilerplate.Domain.Services.Interfaces;
using CleanArchitectureBoilerplate.Models;
using CleanArchitectureBoilerplate.Models.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureBoilerplate.Domain.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository PersonRepository;
        private readonly IPersonMapper PersonMapper;

        public PersonService(IPersonRepository repository, IPersonMapper mapper)
        {
            PersonRepository = repository;
            PersonMapper = mapper;
        }

        public PersonModel Create(PersonCreateRequest request)
        {
            var entity = PersonRepository.Create(PersonMapper.MapCreateRequestToEntity(request));
            return PersonMapper.MapEntityToModel(entity);
        }

        public List<PersonModel> GetAll()
        {
            var PersonList = PersonRepository.GetAll();

            return PersonMapper.MapEntityListToModelList(PersonList);
        }

        public PersonModel Update(PersonUpdateRequest request)
        {
            var entity = PersonMapper.MapUpdateRequestToEntity(request);

            return PersonMapper.MapEntityToModel(PersonRepository.Update(entity));
        }

        public void Delete(int id)
        {
            PersonRepository.Delete(id);
        }
    }
}
