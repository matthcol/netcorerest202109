using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineApiRest.Model;

namespace WineApiRest.Dto
{
    public class AppellationColor
    {
        public string Appellation { get; set; }
        public WineColor? Color { get; set; }
    }
}
