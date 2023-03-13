using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI_TOP_TRUMPSUI.Models
{
    public class PersonModelLinq
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }
        public string[]? Films { get; set; }
        public string[]? Species { get; set; }
        public string[]? Vehicles { get; set; }
    }
}
