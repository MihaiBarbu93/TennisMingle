using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TennisMingle.API.Data;
using TennisMingle.API.Entities;

namespace TennisMingle.API.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/tennisclubs/{tennisClubId}/tenniscourts")]
    public class TennisCourtController : BaseApiController
    {
        private readonly AppDbContext _context;
        public TennisCourtController(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// This GET method returns all the tennis courts from a club 
        /// </summary>
        [HttpGet]
        public IActionResult GetTennisCourts(int cityId, int tennisClubId)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var tennisClub = _context.TennisClubs.FirstOrDefault(tc => tc.Id == tennisClubId);

            if (tennisClub == null)
            {
                return NotFound();
            }

            var tennisCourts = _context.TennisCourts.Include(tc => tc.TennisClub).Include(tc => tc.Surface) ;

            if (tennisCourts == null) 
            {
                return NotFound();
            }

            return Ok(tennisCourts);
        }

        /// <summary>
        /// This GET method returns a tennis court with a specific id 
        /// </summary>
        [HttpGet]
        [Route("{id}", Name = "GetTennisCourt")]
        public IActionResult GetTennisCourt(int cityId, int tennisClubId, int id)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var tennisClub = _context.TennisClubs.FirstOrDefault(tc => tc.Id == tennisClubId);

            if (tennisClub == null)
            {
                return NotFound();
            }

            var tennisCourtToReturn = _context.TennisCourts.Where(tc => tc.Id == id) ;

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
            [FromBody] TennisCourt tennisCourt)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var tennisClub = _context.TennisClubs.FirstOrDefault(tc => tc.Id == tennisClubId);

            if (tennisClub == null)
            {
                return NotFound();
            }


            var tennisCourtToCreate = new TennisCourt()
            {
                Name = tennisCourt.Name,
                Surface = tennisCourt.Surface,
                Price = tennisCourt.Price,
                TennisClubId = tennisClubId
            };

            _context.TennisCourts.Add(tennisCourtToCreate);
            _context.SaveChanges();

            return CreatedAtRoute(
                "GetTennisCourt", new { cityId, tennisClubId, id = _context.TennisCourts.ToList().Last().Id }, tennisCourtToCreate);
        }

        /// <summary>
        /// This PUT method is replacing all the properties of a tennis court
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateTennisCourt(int cityId, int tennisClubId, int id,
            [FromBody] TennisCourt tennisCourt)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var tennisClub = _context.TennisClubs.FirstOrDefault(tc => tc.Id == tennisClubId);

            if (tennisClub == null)
            {
                return NotFound();
            }

            var tennisCourtToUpdate = (from p in _context.TennisCourts
                                  where p.Id == id
                                  select p).SingleOrDefault();

            tennisCourtToUpdate.Name = tennisCourt.Name;
            tennisCourtToUpdate.Surface = tennisCourt.Surface;
            tennisCourtToUpdate.Price = tennisCourt.Price;
            tennisCourtToUpdate.TennisClubId = tennisClubId;

            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// This PATCH method is replacing only one property of a tennis court
        /// </summary>
        [HttpPatch]
        [Route("{id}")]

        public IActionResult PartiallyUpdateTennisCourt(int cityId, int tennisClubId, int id,
            [FromBody] JsonPatchDocument<TennisCourt> patchDoc)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var tennisClub = _context.TennisClubs.FirstOrDefault(tc => tc.Id == tennisClubId);

            if (tennisClub == null)
            {
                return NotFound();
            }

            var tennisCourtFromDb = (from p in _context.TennisCourts
                                where p.Id == id
                                select p).SingleOrDefault();
            if (tennisCourtFromDb == null)
            {
                return NotFound();
            }
            var tennisCourtToPatch = tennisCourtFromDb;

            patchDoc.ApplyTo(tennisCourtToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tennisCourtFromDb.Name = tennisCourtToPatch.Name;
            tennisCourtFromDb.Surface = tennisCourtToPatch.Surface;
            tennisCourtFromDb.Price = tennisCourtToPatch.Price;

            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// This DELETE method removes a tennis court from a club with a specific id 
        /// </summary>
        [HttpDelete]
        [Route("{id}")]

        public IActionResult DeleteTennisCourt(int cityId, int tennisClubId, int id)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var tennisClub = _context.TennisClubs.FirstOrDefault(tc => tc.Id == tennisClubId);

            if (tennisClub == null)
            {
                return NotFound();
            }

            var tennisCourtToDelete = (from p in _context.TennisCourts
                                  where p.Id == id
                                  select p).SingleOrDefault();
            if (tennisCourtToDelete == null)
            {
                return NotFound();
            }

            _context.TennisCourts.Remove(tennisCourtToDelete);
            _context.SaveChanges();

            return NoContent();
        }

    }
}

