using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using AcunMedyaMenu.Models;

namespace AcunMedyaMenu.ViewComponents.DashboardViewComponent
{
    public class _WeatherDashboardComponentPartial : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _WeatherDashboardComponentPartial(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var weatherData = await GetWeatherAsync("Istanbul");
            var model = new WeatherModel
            {
                city_name = weatherData["data"][0]["city_name"].ToString(),
                temp = Convert.ToDouble(weatherData["data"][0]["temp"]),
                
            };
            return View(model);
        }



        private async Task<JObject> GetWeatherAsync(string city)
        {
            string apiKey = "509db683342f4512b73cb6ee64feda73";  // Buraya kendi API anahtarınızı koyun
            string url = $"https://api.weatherbit.io/v2.0/current?city={city}&key={apiKey}&units=M";
            var response = await _httpClient.GetStringAsync(url);
            var weatherData = JObject.Parse(response);
            return weatherData;
        }
    }
}
