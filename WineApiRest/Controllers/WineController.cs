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
    public class WineController : ControllerBase
    {
        // GET: api/<WineController>
        [HttpGet]
        public IEnumerable<Wine> GetAllWines()
        {
            return new Wine[] {
                new Wine
                {
                    Id = 1,
                    Appellation = "Beaujolais",
                    Color = WineColor.ROUGE,
                    Vintage = 2021,
                    AlcoholRate = 12.5f
                },
                    new Wine
                {
                    Id = 2,
                    Appellation = "Jurançon",
                    Color = WineColor.BLANC,
                    Vintage = 2015,
                    AlcoholRate = 11.5f
                }
            };
        }

        // GET api/<WineController>/5
        [HttpGet("{id:long}")]
        public Wine GetWineById([FromRoute] uint id)
        // public string GetWineById(int id)
        {
            return new Wine
            {
                Id = id,
                Appellation = "Beaujolais",
                Color = WineColor.ROUGE,
                Vintage = 2021,
                AlcoholRate = 12.5f
            };
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

        // GET api/<WineController>/byRegionCouleurDegreMillesime?r=Beaujolais&c=rouge&d=12.4
        // GET api/<WineController>/byRegionCouleurDegreMillesime?m=2015-09-22T12:34
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

        // GET api/<WineController>/IsForAging-12
        [HttpGet("IsForAging-{id:long}")]
        // public bool IsForAging([FromRoute] uint id)
        public bool IsForAging(uint id)
        {
            return id %2 == 0;
        }

        // POST api/<WineController>
        [HttpPost]
        // public string Post([FromQuery(Name = "v")] string value)
        // public string Post([FromBody] string value)
        // public Wine Post(Wine wine)
        public Wine Post([FromBody] Wine wine)
        {
            // return $"{value} added with id 12356";
            // TODO : persist object in Database
            // wine.Id = 12356;
            return wine;
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
