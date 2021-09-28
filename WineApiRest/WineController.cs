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
            return new string[] { "beaujolais", "jurançon", "madiran" };
        }

        // GET api/<WineController>/5
        [HttpGet("{id:int}")]
        public string GetWineById([FromRoute] int id)
        // public string GetWineById(int id)
        {
            return $"value {id}";
        }

        // GET /api/<WineController>/rouge
        [HttpGet("rouge")]
        public IEnumerable<string> GetRedWine()
        {
            return new string[] { "rouge1", "rouge2" };
        }

        // GET /api/<WineController>/byRegion?r=Beaujolais
        [HttpGet("byRegion")]
        public IEnumerable<string> GetByRegion([FromQuery(Name = "r")] string region)
        // public IEnumerable<string> GetByRegion(string r) // r is the query param name
        {
            return new string[] {
                $"vin 1 de {region}",
                String.Format("vin 2 de {0}", region)};
        }

        // GET api/wine<WineController>/byRegionCouleurDegreMillesime?r=Beaujolais&c=rouge&d=12.4
        // GET api/wine<WineController>/byRegionCouleurDegreMillesime?m=2015-09-22T12:34
        // recherche par région, couleur, dégré
        [HttpGet("byRegionCouleurDegreMillesime")]
        public IEnumerable<string> GetByRegionCouleurDegre(
            [FromQuery(Name = "r")] string region,
            [FromQuery(Name = "c")] WineColor? couleur,
            [FromQuery(Name = "d")] float? degre,
            [FromQuery(Name = "m")] DateTime? millesime)
        {
            return new string[] {
                $"vin 1 région {region}, couleur {couleur} degré {degre} millesime {millesime}",
                $"vin 2 région {region}, couleur {couleur} degré {degre} millesime {millesime?.Year}"
            };
        }

        // POST api/<WineController>
        [HttpPost]
        // public string Post([FromQuery(Name = "v")] string value)
        public string Post([FromBody] string value)
        {
            return $"{value} added with id 12356";
        }

        // PUT api/<WineController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            return $"{value} #{id} modified";
        }

        // DELETE api/<WineController>
        [HttpDelete]
        public string DeleteAll()
        {
            return $"tous les vins ont été bus (deleted)";
        }

        // DELETE api/<WineController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"vin #{id} deleted";
        }

        
    }
}
