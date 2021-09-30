using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WineApiRest.Model;

namespace WineApiRest.Dto
{
    public class AppellationColor
    {
        public string Appellation { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WineColor? Color { get; set; }
    }
}
