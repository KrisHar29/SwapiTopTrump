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
                //Films = ["https://swapi.dev/api/films/1/", "https://swapi.dev/api/films/2/", "https://swapi.dev/api/films/3/", "https://swapi.dev/api/films/6/"],
                //Species = [],
                //Vehicles = [ "https://swapi.dev/api/vehicles/14/", "https://swapi.dev/api/vehicles/30/" ],

                },
                new PersonModelLinq
                {
                Name =  "Luke Skywalker2",
                Height = "171",
                Mass =  "70",
                HairColor = "blond",
                SkinColor =  "fair",
                EyeColor = "blue",
                BirthYear = "19BBY",
                Gender = "male",
                Homeworld = "https://swapi.dev/api/planets/1/",
                //Films = ["https://swapi.dev/api/films/1/", "https://swapi.dev/api/films/2/", "https://swapi.dev/api/films/3/", "https://swapi.dev/api/films/6/" ],
                //Species = [],
                //Vehicles = [ "https://swapi.dev/api/vehicles/14/", "https://swapi.dev/api/vehicles/30/" ],

                },
                  new PersonModelLinq
                {
                Name =  "Luke Skywalker3",
                Height = "151",
                Mass =  "7",
                HairColor = "blond",
                SkinColor =  "fair",
                EyeColor = "blue",
                BirthYear = "19BBY",
                Gender = "male",
                Homeworld = "https://swapi.dev/api/planets/1/",
                //Films = ["https://swapi.dev/api/films/1/", "https://swapi.dev/api/films/2/", "https://swapi.dev/api/films/3/", "https://swapi.dev/api/films/6/" ],
                //Species = [],
                //Vehicles = [ "https://swapi.dev/api/vehicles/14/", "https://swapi.dev/api/vehicles/30/" ],

                },
                    new PersonModelLinq
                {
                Name =  "Luke Skywalker4",
                Height = "121",
                Mass =  "777",
                HairColor = "blond",
                SkinColor =  "fair",
                EyeColor = "blue",
                BirthYear = "19BBY",
                Gender = "male",
                Homeworld = "https://swapi.dev/api/planets/1/",
                //Films = ["https://swapi.dev/api/films/1/", "https://swapi.dev/api/films/2/", "https://swapi.dev/api/films/3/", "https://swapi.dev/api/films/6/" ],
                //Species = [],
                //Vehicles = [ "https://swapi.dev/api/vehicles/14/", "https://swapi.dev/api/vehicles/30/" ],

                },
                      new PersonModelLinq
                {
                Name =  "Luke Skywalker5",
                Height = "200",
                Mass =  "775",
                HairColor = "blond",
                SkinColor =  "fair",
                EyeColor = "blue",
                BirthYear = "19BBY",
                Gender = "male",
                Homeworld = "https://swapi.dev/api/planets/1/",
                //Films = ["https://swapi.dev/api/films/1/", "https://swapi.dev/api/films/2/", "https://swapi.dev/api/films/3/", "https://swapi.dev/api/films/6/" ],
                //Species = [],
                //Vehicles = [ "https://swapi.dev/api/vehicles/14/", "https://swapi.dev/api/vehicles/30/" ],

                }
            };
        }
        #endregion
    }
}
