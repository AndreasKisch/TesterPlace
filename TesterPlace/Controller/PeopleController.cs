using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesterPlaceAPI.Models;

namespace TesterPlaceAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        List<People> people = new List<People>();

        public PeopleController()
        {

            people.Add(new People { FirstName = "Frodo", LastName = "Baggins", Id = 1 });
            people.Add(new People { FirstName = "Bilbo", LastName = "Baggins", Id = 2 });
            people.Add(new People { FirstName = "Andreas", LastName = "Kisch", Id = 3 });

        }

        // GET: api/People
        [HttpGet]
        public ActionResult<List<People>> Get()
        {
            return people;
        }

        // GET: api/People/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return people[id].FirstName;
        }

        // POST: api/People
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT: api/People/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
