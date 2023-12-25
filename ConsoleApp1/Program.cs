using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string username = "SteveCabral";
            string apiUrl = $"https://api.github.com/users/{username}";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "C# HttpClient");
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Here is the JSON response from GitHub:");
                    Console.WriteLine(jsonResponse);
                }
                else
                {
                    Console.WriteLine($"Failed to fetch user data. Status code: {response.StatusCode}");
                }
            }
        }
    }
}
