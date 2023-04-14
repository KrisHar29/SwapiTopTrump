using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI_TOP_TRUMPSUI.Models
{
    public partial class PeopleRepository
    {
        #region GetAll Method
        public static List<PersonModelLinq> GetAll()
        {
            return new List<PersonModelLinq>
            {
                new PersonModelLinq
                {
                Name =  "Luke Skywalker",
                Height = "172",
                Mass =  "77",
                HairColor = "blond",
                SkinColor =  "fair",
                EyeColor = "blue",
                BirthYear = "19BBY",
                Gender = "male",
                Homeworld = "https://swapi.dev/api/planets/1/",
                Films = new string[] {"https://swapi.dev/api/films/1/", "https://swapi.dev/api/films/2/", "https://swapi.dev/api/films/3/", "https://swapi.dev/api/films/6/" },
                Species = new string[] {},
                Vehicles = new string[] { "https://swapi.dev/api/vehicles/14/", "https://swapi.dev/api/vehicles/30/" },

                },
                new PersonModelLinq
                {
                Name =  "C-3PO",
                Height = "167",
                Mass =  "75",
                HairColor = "n/a",
                SkinColor =  "gold",
                EyeColor = "yellow",
                BirthYear = "112BBY",
                Gender = "n/a",
                Homeworld = "https://swapi.dev/api/planets/1/",
                Films = new string[] {"https://swapi.dev/api/films/1/", "https://swapi.dev/api/films/2/", "https://swapi.dev/api/films/3/", "https://swapi.dev/api/films/4/", "https://swapi.dev/api/films/5/", "https://swapi.dev/api/films/6/" },
                Species = new string[] {},
                Vehicles = new string[] {},

                },
                new PersonModelLinq
                {
                Name =  "R2-D2",
                Height = "96",
                Mass =  "32",
                HairColor = "n/a",
                SkinColor =  "white, blue",
                EyeColor = "red",
                BirthYear = "33BBY",
                Gender = "n/a",
                Homeworld = "https://swapi.dev/api/planets/1/",
                Films = new string[] {"https://swapi.dev/api/films/1/", "https://swapi.dev/api/films/2/", "https://swapi.dev/api/films/3/", "https://swapi.dev/api/films/4/", "https://swapi.dev/api/films/5/", "https://swapi.dev/api/films/6/" },
                Species = new string[] {},
                Vehicles = new string[] {},

                },
                new PersonModelLinq
                {
                Name =  "Darth Vader",
                Height = "202",
                Mass =  "136",
                HairColor = "none",
                SkinColor =  "white",
                EyeColor = "yellow",
                BirthYear = "41.9BBY",
                Gender = "male",
                Homeworld = "https://swapi.dev/api/planets/1/",
                Films = new string[] {"https://swapi.dev/api/films/1/", "https://swapi.dev/api/films/2/", "https://swapi.dev/api/films/3/", "https://swapi.dev/api/films/6/" },
                Species = new string[] {},
                Vehicles = new string[] {},

                },
                new PersonModelLinq
                {
                Name =  "Leia Organa",
                Height = "150",
                Mass =  "49",
                HairColor = "brown",
                SkinColor =  "light",
                EyeColor = "brown",
                BirthYear = "19BBY",
                Gender = "female",
                Homeworld = "https://swapi.dev/api/planets/1/",
                Films = new string[] { "https://swapi.dev/api/films/1/", "https://swapi.dev/api/films/2/", "https://swapi.dev/api/films/3/", "https://swapi.dev/api/films/6/" },
                Species = new string[] {},
                Vehicles = new string[] { "https://swapi.dev/api/vehicles/30/" },

                },
                new PersonModelLinq
                {
                Name =  "Owen Lars",
                Height = "178",
                Mass =  "120",
                HairColor = "brown, grey",
                SkinColor =  "light",
                EyeColor = "blue",
                BirthYear = "52BBY",
                Gender = "male",
                Homeworld = "https://swapi.dev/api/planets/1/",
                Films = new string[] { "https://swapi.dev/api/films/1/", "https://swapi.dev/api/films/5/", "https://swapi.dev/api/films/6/" },
                Species = new string[] {},
                Vehicles = new string[] {},

                },
                new PersonModelLinq
                {
                Name =  "Beru Whitesun lars",
                Height = "165",
                Mass =  "75",
                HairColor = "brown",
                SkinColor =  "light",
                EyeColor = "blue",
                BirthYear = "47BBY",
                Gender = "female",
                Homeworld = "https://swapi.dev/api/planets/1/",
                Films = new string[] {"https://swapi.dev/api/films/1/","https://swapi.dev/api/films/5/", "https://swapi.dev/api/films/6/" },
                Species = new string[] {},
                Vehicles = new string[] {},

                },
                new PersonModelLinq
                {
                Name =  "R5-D4",
                Height = "97",
                Mass =  "32",
                HairColor = "n/a",
                SkinColor =  "white, red",
                EyeColor = "red",
                BirthYear = "unknown",
                Gender = "n/a",
                Homeworld = "https://swapi.dev/api/planets/1/",
                Films = new string[] { "https://swapi.dev/api/films/1/" },
                Species = new string[] {},
                Vehicles = new string[] {},

                },
                new PersonModelLinq
                {
                Name =  "Biggs Darklighter",
                Height = "183",
                Mass =  "84",
                HairColor = "black",
                SkinColor =  "light",
                EyeColor = "brown",
                BirthYear = "24BBY",
                Gender = "male",
                Homeworld = "https://swapi.dev/api/planets/1/",
                Films = new string[] { "https://swapi.dev/api/films/1/" },
                Species = new string[] {},
                Vehicles = new string[] {},

                },
                new PersonModelLinq
                {
                Name =  "Obi-Wan Kenobi",
                Height = "182",
                Mass =  "77",
                HairColor = "auburn, white",
                SkinColor =  "fair",
                EyeColor = "blue-gray",
                BirthYear = "57BBY",
                Gender = "male",
                Homeworld = "https://swapi.dev/api/planets/1/",
                Films = new string[] { "https://swapi.dev/api/films/1/", "https://swapi.dev/api/films/2/", "https://swapi.dev/api/films/3/", "https://swapi.dev/api/films/4/", "https://swapi.dev/api/films/5/", "https://swapi.dev/api/films/6/" },
                Species = new string[] {},
                Vehicles = new string[] { "https://swapi.dev/api/vehicles/38/" },

                }
            };
        }
        #endregion
    }
}
