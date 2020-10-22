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
            List<TennisClubDTO> tennisClubs = new List<TennisClubDTO>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:44313/api/cities/{cityId}/tennisclubs"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    tennisClubs = JsonConvert.DeserializeObject<List<TennisClubDTO>>(apiResponse);
                }
            }

            return View(tennisClubs);
        }
        public async Task<IActionResult> TennisClub(int cityId, int clubId)
        {
            var tennisClub = new TennisClubDTO();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:44313/api/cities/{cityId}/tennisclubs/{clubId}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    tennisClub = JsonConvert.DeserializeObject<TennisClubDTO>(apiResponse);
                }
            }

            return View(tennisClub);
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

