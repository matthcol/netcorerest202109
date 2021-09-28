using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WineApiRest.Model
{
    public class Wine
    {
        public uint? Id { get; set; }
        
        [Required]
        public string Appellation { get; set; }

        public string Variety { get; set; }

       [JsonConverter(typeof(JsonStringEnumConverter))]
        public WineColor? Color { get; set; }

        public short? Vintage { get; set; }

        public float? AlcoholRate { get; set; }
    }
}
