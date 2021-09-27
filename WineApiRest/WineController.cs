using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WineApiRest
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineController : ControllerBase
    {
        // GET: api/<WineController>
        [HttpGet]
        public IEnumerable<string> GetAllWines()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WineController>/5
        [HttpGet("{id}")]
        public string GetWineById(int id)
        {
            return "value";
        }

        [HttpGet("rouge")]
        public IEnumerable<string> GetRedWine()
        {
            return new string[] { "rouge1", "rouge2" };
        }



        // POST api/<WineController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WineController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
