using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

       // [HttpGet("{tennisclubid}", Name = "GetTennisClub")]
        [HttpGet("{tennisClubId}")]
        public IActionResult GetTennisClub(int cityId, int tennisClubId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var tennisClub = city.TennisClubs.FirstOrDefault(tc => tc.Id == tennisClubId);
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
                TennisCourts = tennisClub.TennisCourts,
                Coaches = tennisClub.Coaches,
                Surfaces = tennisClub.Surfaces,
                Facilities = tennisClub.Facilities,
                Address = tennisClub.Address,
                PhoneNumber = tennisClub.PhoneNumber,
                Description = tennisClub.Description,
                Prices = tennisClub.Prices,
                Schedule = tennisClub.Schedule,
                Image = tennisClub.Image
            };
            city.TennisClubs.Add(createdTennisClub);
            return CreatedAtRoute("GetTennisClub", new { cityId, tennisclubid = createdTennisClub.Id }, createdTennisClub);
        }

        [HttpPut("{tennisClubId}")]
        public IActionResult UpdateTennisClub(int cityId, int tennisClubId,
            [FromBody] TennisClubForUpdateDTO tennisClub)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var tennisClubFromStore = city.TennisClubs.FirstOrDefault(tc => tc.Id == tennisClubId);
            if (tennisClubFromStore == null)
            {
                return NotFound();
            }
            tennisClubFromStore.Name = tennisClub.Name;
            tennisClubFromStore.TennisCourts = tennisClub.TennisCourts;
            tennisClubFromStore.Coaches = tennisClub.Coaches;
            tennisClubFromStore.Surfaces = tennisClub.Surfaces;
            tennisClubFromStore.Facilities = tennisClub.Facilities;
            tennisClubFromStore.Address = tennisClub.Address;
            tennisClubFromStore.PhoneNumber = tennisClub.PhoneNumber;
            tennisClubFromStore.Description = tennisClub.Description;
            tennisClubFromStore.Prices = tennisClub.Prices;
            tennisClubFromStore.Schedule = tennisClub.Schedule;
            tennisClubFromStore.Image = tennisClub.Image;

            return NoContent();
        }

        [HttpPatch("{tennisClubId}")]
        public IActionResult PartiallyUpdateTennisClub(int cityId, int tennisClubId,
            [FromBody] JsonPatchDocument<TennisClubForUpdateDTO> patchDoc)
        {

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var tennisClubFromStore = city.TennisClubs.FirstOrDefault(tc => tc.Id == tennisClubId);
            if (tennisClubFromStore == null)
            {
                return NotFound();
            }
            var tennisClubToPatch =
                new TennisClubForUpdateDTO()
                {

                    Name = tennisClubFromStore.Name,
                    TennisCourts = tennisClubFromStore.TennisCourts,
                    Coaches = tennisClubFromStore.Coaches,
                    Surfaces = tennisClubFromStore.Surfaces,
                    Facilities = tennisClubFromStore.Facilities,
                    Address = tennisClubFromStore.Address,
                    PhoneNumber = tennisClubFromStore.PhoneNumber,
                    Description = tennisClubFromStore.Description,
                    Prices = tennisClubFromStore.Prices,
                    Schedule = tennisClubFromStore.Schedule,
                    Image = tennisClubFromStore.Image
                };
            patchDoc.ApplyTo(tennisClubToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tennisClubFromStore.Name = tennisClubToPatch.Name;
            tennisClubFromStore.TennisCourts = tennisClubToPatch.TennisCourts;
            tennisClubFromStore.Coaches = tennisClubToPatch.Coaches;
            tennisClubFromStore.Surfaces = tennisClubToPatch.Surfaces;
            tennisClubFromStore.Facilities = tennisClubToPatch.Facilities;
            tennisClubFromStore.Address = tennisClubToPatch.Address;
            tennisClubFromStore.PhoneNumber = tennisClubToPatch.PhoneNumber;
            tennisClubFromStore.Description = tennisClubToPatch.Description;
            tennisClubFromStore.Prices = tennisClubToPatch.Prices;
            tennisClubFromStore.Schedule = tennisClubToPatch.Schedule;
            tennisClubFromStore.Image = tennisClubToPatch.Image;

            return NoContent();
        }

        [HttpDelete("{tennisClubId}")]
        public IActionResult DeleteTennisClub(int cityId, int tennisClubId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var tennisClubFromStore = city.TennisClubs.FirstOrDefault(tc => tc.Id == tennisClubId);
            if (tennisClubFromStore == null)
            {
                return NotFound();
            }

            city.TennisClubs.Remove(tennisClubFromStore);

            return NoContent();
        }
    }
}
