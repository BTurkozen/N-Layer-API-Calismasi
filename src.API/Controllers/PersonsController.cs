using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using src.Core.Models;
using src.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _personService;

        public PersonsController(IService<Person> service)
        {
            _personService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var person =  await _personService.GetByIdAsync(id);
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var newPerson = await _personService.AddAsync(person);

            return Created(string.Empty, newPerson);
        }

    }
}
