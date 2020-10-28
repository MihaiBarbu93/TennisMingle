using System;
using System.Collections.Generic;
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
    public class CitiesController : Controller
    {
        private readonly ILogger<CitiesController> _logger;

        public CitiesController(ILogger<CitiesController> logger)
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
                    entity.TennisClubs = JsonConvert.DeserializeObject<HashSet<TennisClub>>(apiResponse, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                    });

                    var tennisClubsWithDistinctCities = entity.TennisClubs.DistinctBy(tc => tc.Address.City.Name);

                    foreach (var tennisClub in tennisClubsWithDistinctCities)
                    {
                        entity.Cities.Add(tennisClub.Address.City);
                    }

                }
                using (var response = await httpClient.GetAsync($"https://localhost:44313/api/cities/{cityId}/tennisclubs/{entity.TennisClubs.FirstOrDefault().Id}/tenniscourts"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    entity.TennisCourts = JsonConvert.DeserializeObject<HashSet<TennisCourt>>(apiResponse);
                    foreach (var tennisCourt in entity.TennisCourts)
                    {
                        entity.Surfaces.Add(tennisCourt.Surface);
                    }

                    /*                    entity.Surfaces = entity.Surfaces.GroupBy(s => s.Id).SelectMany(su => su).ToList();*/
                }
            }

            return View(entity);
        }
    }
}
