/*using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TennisMingle.API.Models;

namespace TennisMingle.API.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/tennisclubs/{tennisClubId}/tenniscourts")]
    public class TennisCourtController : ControllerBase
    {
        /// <summary>
        /// This GET method returns all the tennis courts from a club 
        /// </summary>
        [HttpGet]
        public IActionResult GetTennisCourts(int cityId, int tennisClubId)
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

            return Ok(tennisClub.TennisCourts);
        }

        /// <summary>
        /// This GET method returns a tennis court with a specific id 
        /// </summary>
        [HttpGet]
        [Route("{id}", Name = "GetTennisCourt")]
        public IActionResult GetTennisCourt(int cityId, int tennisClubId, int id)
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

            var tennisCourtToReturn = tennisClub.TennisCourts.FirstOrDefault(tco => tco.Id == id);

            if (tennisCourtToReturn == null)
            {
                return NotFound();
            }

            return Ok(tennisCourtToReturn);
        }

        /// <summary>
        /// This POST method creates a tennis court which is added to a club
        /// </summary>
        [HttpPost]
        public IActionResult CreateTennisCourt(int cityId, int tennisClubId,
            [FromBody] TennisCourtDTOForCreation tennisCourt)
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

            var maxTennisCourtId = city.TennisClubs.SelectMany(tc => tc.TennisCourts).Max(tco => tco.Id);

            var tennisCourtToCreate = new TennisCourtDTO()
            {
                Id = ++maxTennisCourtId,
                Name = tennisCourt.Name,
                Surface = tennisCourt.Surface,
                Price = tennisCourt.Price
            };

            tennisClub.TennisCourts.Add(tennisCourtToCreate);

            return CreatedAtRoute(
                "GetTennisCourt", new { cityId, tennisClubId, id = tennisCourtToCreate.Id }, tennisCourtToCreate);
        }

        /// <summary>
        /// This PUT method is replacing all the properties of a tennis court
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateTennisCourt(int cityId, int tennisClubId, int id,
            [FromBody] TennisCourtDTOForUpdate tennisCourt)
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

            var tennisCourtToUpdate = tennisClub.TennisCourts.FirstOrDefault(tco => tco.Id == id);

            tennisCourtToUpdate.Name = tennisCourt.Name;
            tennisCourtToUpdate.Surface = tennisCourt.Surface;
            tennisCourtToUpdate.Price = tennisCourt.Price;

            return NoContent();
        }

        /// <summary>
        /// This PATCH method is replacing only one property of a tennis court
        /// </summary>
        [HttpPatch]
        [Route("{id}")]

        public IActionResult PartiallyUpdateTennisCourt(int cityId, int tennisClubId, int id,
            [FromBody] JsonPatchDocument<TennisCourtDTOForUpdate> patchDoc)
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

            var tennisCourtFromStore = tennisClub.TennisCourts.FirstOrDefault(tco => tco.Id == id);

            if (tennisCourtFromStore == null)
            {
                return NotFound();
            }

            var tennisCourtToPatch = new TennisCourtDTOForUpdate()
            {
                Name = tennisCourtFromStore.Name,
                Surface = tennisCourtFromStore.Surface,
                Price = tennisCourtFromStore.Price
            };

            patchDoc.ApplyTo(tennisCourtToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tennisCourtFromStore.Name = tennisCourtToPatch.Name;
            tennisCourtFromStore.Surface = tennisCourtToPatch.Surface;
            tennisCourtFromStore.Price = tennisCourtToPatch.Price;

            return NoContent();
        }

        /// <summary>
        /// This DELETE method removes a tennis court from a club with a specific id 
        /// </summary>
        [HttpDelete]
        [Route("{id}")]

        public IActionResult DeleteTennisCourt(int cityId, int tennisClubId, int id)
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

            var tennisCourtToDelete = tennisClub.TennisCourts.FirstOrDefault(tco => tco.Id == id);

            if (tennisCourtToDelete == null)
            {
                return NotFound();
            }

            tennisClub.TennisCourts.Remove(tennisCourtToDelete);

            return NoContent();
        }

    }
}

*/