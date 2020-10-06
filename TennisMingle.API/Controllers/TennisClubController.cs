using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Models;

namespace TennisMingle.API.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/tennisclubs")]
    public class TennisClubController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTennisClubs(int cityId) 
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null) 
            {
                return NotFound();
            }
            return Ok(city.TennisClubs);
        }

        [HttpGet("{tennisclubid}", Name = "GetTennisClub")]
        public IActionResult GetTennisClub(int cityId, int tennisclubid) 
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var tennisClub = city.TennisClubs.FirstOrDefault(tc => tc.Id == tennisclubid);
            if (tennisClub == null)
            {
                return NotFound();
            }
            return Ok(tennisClub);
        }

        [HttpPost]
        public IActionResult CreateTennisClub(int cityId, [FromBody] TennisClubForCreationDTO tennisClub) 
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var maxTennisClubId = CitiesDataStore.Current.Cities.SelectMany(c => c.TennisClubs).Max(tc => tc.Id);
            var createdTennisClub = new TennisClubDTO()
            {
                Id = ++maxTennisClubId,
                Name = tennisClub.Name,
                Surface = tennisClub.Surface,
                Facilities = tennisClub.Facilities,
                Address = tennisClub.Address,
                PhoneNumber = tennisClub.PhoneNumber,
                Description = tennisClub.Description,
                Prices = tennisClub.Prices,
                Schedule = tennisClub.Schedule,
                Image = tennisClub.Image
            };
            city.TennisClubs.Add(createdTennisClub);
            return CreatedAtRoute("GetTennisClub", new { cityId, tennisclubid = createdTennisClub.Id }, createdTennisClub) ;

        }





    }
}
