using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SWAPI_TOP_TRUMPSUI
{
    public class RequestSWAPIToFile
    {
        private static readonly HttpClient client = new HttpClient();
        //test method
        public async Task Main()
        {
            string url = "https://swapi.dev/api/people/1";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(responseBody);

                //// Deserialize the JSON array into a C# object or collection
                //var data = JsonSerializer.Deserialize<object[]>(responseBody);

                // Save the data to a file
                //string json = JsonSerializer.Serialize(responseBody);
                File.WriteAllText("data.json", responseBody);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }
        // iterates through api 83 times (17 is broken link) to download all 82
        // people from swapi.dev
        public async Task RequestAllPeople()
        {
            string requestedPeople = "[ ";

            for (int i = 1; i <= 83; i++)
            {
                // because card api/17 does not exist we do not print 
                // a message to console to say this card hasnt loaded
                if (i == 17)
                {
                    
                }
                // by the same merit because we know 17 does not exist
                // we want the last card to be loaded to be 82 and not 83
                // as we only have 82 sets of card data.
                else if (i >17)
                {
                    string url = $"https://swapi.dev/api/people/{i}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    Requesting(i-1);
                    if (i % 10 == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("=== Requesting Data ===");
                    }
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        //Add data to playercarddata
                        if (i == 83)
                        {
                            requestedPeople += responseBody + "]";
                        }
                        else
                        {
                            requestedPeople += responseBody + ", ";
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} at index {i-1}");
                    }
                }
                else
                {
                    string url = $"https://swapi.dev/api/people/{i}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    Requesting(i);
                    if (i % 10 == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("=== Requesting Data ===");
                    }
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        //Add data to playercarddata
                        if (i == 83)
                        {
                            requestedPeople += responseBody + "]";
                        }
                        else
                        {
                            requestedPeople += responseBody + ", ";
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} at index {i}");
                    }
                }
               
            }

            if (requestedPeople != "[ ")
            {
                File.WriteAllText("playercarddata.json", requestedPeople);
            }

            // added to clear console and give the feedback that the task completed.
            Console.WriteLine("Card Data downloaded.\nPress any key to continue.");
            //Console.ReadLine();
            Console.Clear();
        }



        //request vehicles
        public async Task RequestAllVehicles()
        {
            string requestedPeople = "[ ";

            for (int i = 1; i <= 83; i++)
            {
                // because card api/17 does not exist we do not print 
                // a message to console to say this card hasnt loaded
                if (i == 17)
                {

                }
                // by the same merit because we know 17 does not exist
                // we want the last card to be loaded to be 82 and not 83
                // as we only have 82 sets of card data.
                else if (i > 17)
                {
                    string url = $"https://swapi.dev/api/people/{i}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    Requesting(i - 1);
                    if (i % 10 == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("=== Requesting Data ===");
                    }
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        //Add data to playercarddata
                        if (i == 83)
                        {
                            requestedPeople += responseBody + "]";
                        }
                        else
                        {
                            requestedPeople += responseBody + ", ";
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} at index {i - 1}");
                    }
                }
                else
                {
                    string url = $"https://swapi.dev/api/people/{i}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    Requesting(i);
                    if (i % 10 == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("=== Requesting Data ===");
                    }
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        //Add data to playercarddata
                        if (i == 83)
                        {
                            requestedPeople += responseBody + "]";
                        }
                        else
                        {
                            requestedPeople += responseBody + ", ";
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} at index {i}");
                    }
                }

            }

            if (requestedPeople != "[ ")
            {
                File.WriteAllText("playercarddata.json", requestedPeople);
            }

            // added to clear console and give the feedback that the task completed.
            Console.WriteLine("Card Data downloaded.\nPress any key to continue.");
            //Console.ReadLine();
            Console.Clear();
        }

        //prints requesting card number
        private void Requesting(int i)
        {
            Console.WriteLine($"Requesting Card Number {i}");
        }
    }
}
