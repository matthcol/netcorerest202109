using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineApiRest.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WineApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkerController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Drinker Get(int id)
        {
            return new Drinker
            {
                Id = id,
                Name = "Matthias",
                Birthdate = new DateTime(1975, 2, 28)
            };
        }

        // POST api/<ValuesController>
        [HttpPost]
        public Drinker Post([FromBody] Drinker drinker)
        {
            drinker.Id = 123456;
            return drinker;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
