using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoreLinq;
using Newtonsoft.Json;
using TennisMingle.API.Models;
using TennisMingle.WEB.Models;

namespace TennisMingle.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            EntityViewModel entity = new EntityViewModel();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44313/api/cities"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    entity.Cities = JsonConvert.DeserializeObject<HashSet<City>>(apiResponse);
                }
            }

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44313/api/persons")) {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    entity.Persons = JsonConvert.DeserializeObject<HashSet<Person>>(apiResponse);
                }
            }


            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:44313/api/cities/{entity.Cities.FirstOrDefault().Id}/tennisclubs"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    entity.TennisClubs = JsonConvert.DeserializeObject<HashSet<TennisClub>>(apiResponse, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                    });

                }
                using (var response = await httpClient.GetAsync($"https://localhost:44313/api/cities/{entity.Cities.FirstOrDefault().Id}/tennisclubs/{entity.TennisClubs.FirstOrDefault().Id}/tenniscourts"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    entity.TennisCourts = JsonConvert.DeserializeObject<HashSet<TennisCourt>>(apiResponse);
                    foreach (var tennisCourt in entity.TennisCourts)
                    {
                        entity.Surfaces.Add(tennisCourt.Surface);
                    }

                    /* entity.Surfaces = entity.Surfaces.GroupBy(s => s.Id).SelectMany(su => su).ToList();*/
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
