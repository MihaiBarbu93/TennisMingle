using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
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
                    entity.TennisClubs = JsonConvert.DeserializeObject<HashSet<TennisClub>>(apiResponse, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                    }); 
                    foreach (var tennisClub in entity.TennisClubs)
                    {
                         entity.Cities.Add(tennisClub.Address.City);
                    }
                }
                using (var response = await httpClient.GetAsync($"https://localhost:44313/api/cities/{cityId}/tennisclubs/{entity.TennisClubs.FirstOrDefault().Id}/tenniscourts")) {
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

        public async Task<IActionResult> TennisClub(int cityId, int tennisClubId)
        {
            EntityViewModel entity = new EntityViewModel();


            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:44313/api/cities/{cityId}/tennisclubs/{tennisClubId}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var TC = JsonConvert.DeserializeObject<HashSet<TennisClub>>(apiResponse);
                    entity.TennisClub = TC.FirstOrDefault();


                }
                foreach (var tennisCourt in entity.TennisClub.TennisCourts)
                {
                    entity.TennisClub.Prices.Add(tennisCourt.Price);
                }
                entity.Cities.Add(entity.TennisClub.Address.City);

                using (var response = await httpClient.GetAsync($"https://localhost:44313/api/cities/{cityId}/tennisclubs"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var tennisClubs = JsonConvert.DeserializeObject<List<TennisClub>>(apiResponse, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                    }).ToList();
                    entity.TennisClubs = new HashSet<TennisClub>(tennisClubs.Where(tc => tc.Id != tennisClubId));
                    foreach (var tennisClub in entity.TennisClubs)
                    {
                        entity.Cities.Add(tennisClub.Address.City);
                    }
                }
                
                
                
            }

            return View(entity);
        }

        [HttpPost]

        public async Task<IActionResult> BookCourt(int cityId, int tennisClubId, Booking booking)
        {
            Booking receivedBooking = new Booking();
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(booking.FirstName), "FirstName");
                content.Add(new StringContent(booking.LastName), "LastName");
                content.Add(new StringContent(booking.PhoneNumber), "PhoneNumber");
                content.Add(new StringContent(booking.DateStart.ToString()), "DateStart");
                content.Add(new StringContent(booking.DateStart.AddHours(booking.Duration).ToString()), "DateEnd");
                using (var response = await httpClient.GetAsync($"https://localhost:44313/api/cities/{cityId}/tennisclubs/{tennisClubId}/tenniscourts"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var tennisCourts = JsonConvert.DeserializeObject<List<TennisCourt>>(apiResponse);
                    TennisCourt tennisCourt = tennisCourts.Where(tc => tc.IsAvailable == true).FirstOrDefault();
                    content.Add(new StringContent(tennisCourt.Id.ToString()), "TennisCourtId");

                }
                using (var response = await httpClient.PostAsync($"https://localhost:44313/api/tennisclubs/{tennisClubId}/booking", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    receivedBooking = JsonConvert.DeserializeObject<Booking>(apiResponse);
                }
            }
            /*      return CreatedAtAction("TennisClub", new { cityId, tennisClubId}, receivedBooking);*/
            return NoContent();
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

