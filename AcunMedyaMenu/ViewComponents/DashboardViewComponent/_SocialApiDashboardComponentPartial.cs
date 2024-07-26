using System;
using System.Net.Http;
using System.Threading.Tasks;
using AcunMedyaMenu.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AcunMedyaMenu.ViewComponents.DashboardViewComponent
{
    public class _SocialApiDashboardComponentPartial : ViewComponent
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<IViewComponentResult> InvokeAsync(string username)
        {

            var instagramData = await GetInstagramDataAsync(username);

            var model = new SocialApiModel
            {
                Followers = instagramData.followers,
                Following = instagramData.following
            };

            return View(model);
        }

        private async Task<(int followers, int following)> GetInstagramDataAsync(string username)
        {
            try
            {
                var followers = await GetFollowersCountAsync(username);
                var following = await GetFollowingCountAsync(username);

                return (followers, following);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return (0, 0);
            }
        }

        private async Task<int> GetFollowersCountAsync(string username)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://instagram-scraper-api2.p.rapidapi.com/v1/followers?username_or_id_or_url={username}"),
                    Headers =
                    {
                        { "x-rapidapi-key", "6eabf55467msh151f3b14d4cbba9p13a39ejsna73ee93eee87" },
                        { "x-rapidapi-host", "instagram-scraper-api2.p.rapidapi.com" },
                    },
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Followers Response: {body}");

                    var json = JObject.Parse(body);
                    int followers = (int)json["data"]["total"];

                    return followers;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return 0;
            }
        }

        private async Task<int> GetFollowingCountAsync(string username)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://instagram-scraper-api2.p.rapidapi.com/v1/following?username_or_id_or_url={username}"),
                    Headers =
                    {
                        { "x-rapidapi-key", "6eabf55467msh151f3b14d4cbba9p13a39ejsna73ee93eee87" },
                        { "x-rapidapi-host", "instagram-scraper-api2.p.rapidapi.com" },
                    },
                };

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Following Response: {body}");

                        var json = JObject.Parse(body);
                        int following = (int)json["data"]["total"];
                        return following;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                        return 0;
                    }
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return 0;
            }
        }
    }
}
