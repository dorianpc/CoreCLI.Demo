using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace person_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        IPeopleProvider _provider;

        public PeopleController(IPeopleProvider provider)
        {
            this._provider = provider;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _provider.GetPeople();
        }

        [HttpGet("{id}")]
        public Person Get(int id)
        {
            try
            {
                return _provider.GetPerson(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
