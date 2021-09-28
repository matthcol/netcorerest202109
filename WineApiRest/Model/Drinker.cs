using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WineApiRest.Tools;

namespace WineApiRest.Model
{
    public class Drinker
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonConverter(typeof(DateConverter))]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}
