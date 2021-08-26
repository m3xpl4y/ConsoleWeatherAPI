using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleWeatherAPI
{
    class Program
    {

        static async Task Main(string[] args)
        {
            string apiKey = "8e3ad4a03522edcad4c7c354ce9c44a8";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org");

            Console.Write("Bitte Stadtnamen eingeben: ");
            string chooseCity = Console.ReadLine();
            var response = await client.GetAsync($"/data/2.5/weather?q={chooseCity}&units=metric&lang=de&appid={apiKey}");

            
            var stringResult = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<dynamic>(stringResult);
            var city = obj.name;
            var humidity = obj.main.humidity;
            var cloudly = obj.weather[0].description;
            var tmpDegreesF = Math.Round(((float)obj.main.temp));
            Console.WriteLine($"Derzeitige Temperatur in {city} ist {tmpDegreesF}°C und Feuchtigkeit ist {humidity} und {cloudly}");
            Console.WriteLine("Beliebge Taste Drücken um zu beenden!");
            Console.ReadKey();


        }
    }
}
