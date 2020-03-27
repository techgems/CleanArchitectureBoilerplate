using CleanArchitectureBoilerplate.Domain.Services.Interfaces;
using CleanArchitectureBoilerplate.Models;
using CleanArchitectureBoilerplate.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureBoilerplate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService PersonService;

        public PersonController(IPersonService personService)
        {
            PersonService = personService;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<PersonModel>> GetAll()
        {
            return Ok(PersonService.GetAll());
        }

        [HttpPost]
        [Route("")]
        public ActionResult<PersonModel> Create(PersonCreateRequest request)
        {
            return Ok(PersonService.Create(request));
        }

        [HttpPut]
        [Route("")]
        public ActionResult<PersonModel> Update(PersonUpdateRequest request)
        {
            return Ok(PersonService.Update(request));
        }

        [HttpDelete]
        [Route("")]
        public ActionResult Delete(int id)
        {
            PersonService.Delete(id);
            return Ok();
        }
    }
}
