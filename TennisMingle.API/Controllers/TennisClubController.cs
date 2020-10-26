using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TennisMingle.API.Models;

namespace TennisMingle.API.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/tennisclubs")]
    public class TennisClubController : ControllerBase
    {
        private AppDbContext _context;

        public TennisClubController(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// This GET method returns all the tennis clubs from a city
        /// </summary>
        [HttpGet]
        public IActionResult GetTennisClubs(int cityId)
        {
            var city = _context.Cities.Where(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var tennisClubs = _context.TennisClubs.Include(tc => tc.Address.City).Where(tc => tc.Address.CityId == cityId);

            return Ok(tennisClubs.ToList());
        }

        /// <summary>
        /// This GET method returns a tennis club with a specific id 
        /// </summary>
        [HttpGet]
        [Route("{tennisClubId}", Name = "GetTennisClub")]
        public IActionResult GetTennisClub(int cityId, int tennisClubId)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var tennisClub = _context.TennisClubs.Include(tc => tc.Address.City).Where(tc => tc.Id == tennisClubId);
            if (tennisClub == null)
            {
                return NotFound();
            }

            return Ok(tennisClub);
        }

        /// <summary>
        /// This POST method creates a tennis club which is added to a city
        /// </summary>
        [HttpPost]
        public IActionResult CreateTennisClub(int cityId, [FromBody] TennisClub tennisClub)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            _context.Addresses.Add(tennisClub.Address);
            _context.SaveChanges();

            var tennisClubToAdd = new TennisClub
            {
                Name = tennisClub.Name,
                PhoneNumber = tennisClub.PhoneNumber,
                AddressId = _context.Addresses.ToList().Last().Id,
                Description = tennisClub.Description,
                Schedule = tennisClub.Schedule,
                Image = tennisClub.Image
            };

            _context.TennisClubs.Add(tennisClubToAdd);
            _context.SaveChanges();
            return CreatedAtRoute("GetTennisClub", new { cityId, tennisClubId = _context.TennisClubs.ToList().Last().Id }, tennisClubToAdd);
        }

        /// <summary>
        /// This PUT method is replacing all the properties of a tennis club
        /// </summary>
        [HttpPut("{tennisClubId}")]
        public IActionResult UpdateTennisClub(int cityId, int tennisClubId,
            [FromBody] TennisClub tennisClub)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = _context.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var tennisClubFromDB = _context.TennisClubs.FirstOrDefault(tc => tc.Id == tennisClubId);
            if (tennisClubFromDB == null)
            {
                return NotFound();
            }

            var addressToReplace = _context.Addresses.FirstOrDefault(a => a.Id == tennisClubFromDB.AddressId);

            tennisClubFromDB.Name = tennisClub.Name;
            addressToReplace = tennisClub.Address;
            tennisClubFromDB.PhoneNumber = tennisClub.PhoneNumber;
            tennisClubFromDB.Description = tennisClub.Description;
            tennisClubFromDB.Schedule = tennisClub.Schedule;
            tennisClubFromDB.Image = tennisClub.Image;

            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// This PATCH method is replacing only one property of a tennis club
        /// </summary>
        [HttpPatch("{tennisClubId}")]
        public IActionResult PartiallyUpdateTennisClub(int cityId, int tennisClubId,
            [FromBody] JsonPatchDocument<TennisClub> patchDoc)
        {

            var city = _context.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var tennisClubFromDB = _context.TennisClubs.FirstOrDefault(tc => tc.Id == tennisClubId);
            if (tennisClubFromDB == null)
            {
                return NotFound();
            }
            var tennisClubToPatch = tennisClubFromDB;

            patchDoc.ApplyTo(tennisClubToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tennisClubFromDB.Name = tennisClubToPatch.Name;
            tennisClubFromDB.Address = tennisClubToPatch.Address;
            tennisClubFromDB.PhoneNumber = tennisClubToPatch.PhoneNumber;
            tennisClubFromDB.Description = tennisClubToPatch.Description;
            tennisClubFromDB.Schedule = tennisClubToPatch.Schedule;
            tennisClubFromDB.Image = tennisClubToPatch.Image;

            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// This DELETE method removes a tennis club from a city with a specific id 
        /// </summary>
        [HttpDelete("{tennisClubId}")]
        public IActionResult DeleteTennisClub(int cityId, int tennisClubId)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var tennisClubFromStore = _context.TennisClubs.FirstOrDefault(tc => tc.Id == tennisClubId);
            if (tennisClubFromStore == null)
            {
                return NotFound();
            }

            _context.TennisClubs.Remove(tennisClubFromStore);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
