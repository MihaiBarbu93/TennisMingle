using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TennisMingle.API.Models;
using TennisMingle.WEB.Models;

namespace TennisMingle.WEB.Controllers
{
    public class TennisClubController : Controller
    {
        private readonly ILogger<TennisClubController> _logger;

        public TennisClubController(ILogger<TennisClubController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> TennisClubs(int cityId)
        {
            EntityViewModel entity = new EntityViewModel();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:44313/api/cities/{cityId}/tennisclubs"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    entity.TennisClubs = JsonConvert.DeserializeObject<List<TennisClub>>(apiResponse);
                }
                using (var response = await httpClient.GetAsync("https://localhost:44313/api/cities"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    entity.Cities = JsonConvert.DeserializeObject<List<City>>(apiResponse);
                }
            }

            return View(entity);
        }
        public async Task<IActionResult> TennisClub(int cityId, int clubId)
        {
            EntityViewModel entity = new EntityViewModel();


            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:44313/api/cities/{cityId}/tennisclubs/{clubId}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    entity.TennisClubs = JsonConvert.DeserializeObject<List<TennisClub>>(apiResponse);
                }
                using (var response = await httpClient.GetAsync("https://localhost:44313/api/cities"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    entity.Cities = JsonConvert.DeserializeObject<List<City>>(apiResponse);
                }
            }

            return View(entity);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

