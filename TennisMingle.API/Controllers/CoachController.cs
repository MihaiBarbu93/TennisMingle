using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TennisMingle.API.Models;

namespace TennisMingle.API.Controllers
{
    [ApiController]
    [Route("api/cities/{cityid}/tennisclubs/{tennisclubid}/tenniscoaches")]
    public class CoachController: ControllerBase
    {
        [HttpGet]
        public IActionResult GetTennisCoaches(int cityId, int tennisClubId)
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

            return Ok(tennisClub.Coaches);
        }

        [HttpGet]
        [Route("{id}", Name= "GetTennisCoach")]
        public IActionResult GetTennisCoach(int cityId, int tennisClubId, int id)
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

            var tennisCoachToReturn = tennisClub.Coaches.FirstOrDefault(co => co.Id == id);

            if (tennisCoachToReturn == null)
            {
                return NotFound();
            }

            return Ok(tennisCoachToReturn);
        }

        [HttpPost]
        public IActionResult CreateCoach(int cityId, int tennisClubId,
            [FromBody] CoachDTOForCreation coach)
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

            var maxCoachId = city.TennisClubs.SelectMany(tc => tc.Coaches).Max(c => c.Id);

            var coachToCreate = new CoachDTO()
            {
                Id = ++maxCoachId,
                Name = coach.Name,
                Bio = coach.Bio,
                Photo = coach.Photo
            };

            tennisClub.Coaches.Add(coachToCreate);

            return CreatedAtRoute(
                "GetTennisCoach", new { cityId, tennisClubId, id = coachToCreate.Id }, coachToCreate);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateCoach(int cityId, int tennisClubId, int id,
            [FromBody] CoachDTOForUpdate coach)
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

            var coachToUpdate = tennisClub.Coaches.FirstOrDefault(co => co.Id == id);

            coachToUpdate.Name = coach.Name;
            coachToUpdate.Bio = coach.Bio;
            coachToUpdate.Photo = coach.Photo;

            return NoContent();
        }

        [HttpPatch]
        [Route("{id}")]

        public IActionResult PartiallyUpdateCoach(int cityId, int tennisClubId, int id,
            [FromBody] JsonPatchDocument<CoachDTOForUpdate> patchDoc)
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

            var coachFromStore = tennisClub.Coaches.FirstOrDefault(co => co.Id == id);

            if (coachFromStore == null)
            {
                return NotFound();
            }

            var coachToPatch = new CoachDTOForUpdate()
            {
                Name = coachFromStore.Name,
                Bio = coachFromStore.Bio,
                Photo = coachFromStore.Photo
            };

            patchDoc.ApplyTo(coachToPatch, ModelState);
         
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            coachFromStore.Name = coachToPatch.Name;
            coachFromStore.Bio = coachToPatch.Bio;
            coachFromStore.Photo = coachToPatch.Photo;

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]

        public IActionResult DeleteCoach(int cityId, int tennisClubId, int id)
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

            var coachToDelete = tennisClub.Coaches.FirstOrDefault(co => co.Id == id);

            if (coachToDelete == null)
            {
                return NotFound();
            }

            tennisClub.Coaches.Remove(coachToDelete);

            return NoContent();
        }

    }
}
