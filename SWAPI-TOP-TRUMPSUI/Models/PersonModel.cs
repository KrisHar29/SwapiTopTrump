using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SWAPI_TOP_TRUMPSUI.Models
{

    //Can clearly not use certain information eg;
    // hair color, skin color, eye color, species, homeworld

    public class PersonModel
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("height")]
        public string? Height { get; set; }

        [JsonPropertyName("mass")]
        public string? Mass { get; set; }

        [JsonPropertyName("hair_color")]
        public string? HairColor { get; set; }

        [JsonPropertyName("skin_color")]
        public string? SkinColor { get; set; }

        [JsonPropertyName("eye_color")]
        public string? EyeColor { get; set; }

        [JsonPropertyName("birth_year")]
        public string? BirthYear { get; set; }

        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        [JsonPropertyName("homeworld")]
        public string? Homeworld { get; set; }

        [JsonPropertyName("films")]
        public string[]? Films { get; set; }

        [JsonPropertyName("species")]
        public string[]? Species { get; set; }

        [JsonPropertyName("vehicles")]
        public string[]? Vehicles { get; set; }
    }
}
