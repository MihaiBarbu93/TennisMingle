using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TennisMingle.API.Data;
using TennisMingle.API.Entities;

namespace TennisMingle.API.Controllers
{
   
    public class BookingController : BaseApiController
    {
        private readonly AppDbContext _context;
        public BookingController(AppDbContext context)
        {
            _context = context;
        }
 
        [HttpGet]
        [Route("{id}", Name = "GetBooking")]
        public IActionResult GetBooking(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(c => c.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        
        [HttpPost]
        public IActionResult BookTennisCourt(int tennisClubId,
            [FromBody] Booking booking)
        {

            var tennisClub = _context.TennisClubs.Include(tennisClub => tennisClub.TennisCourts).FirstOrDefault(tc => tc.Id == tennisClubId);

            if (tennisClub == null)
            {
                return NotFound();
            }
            if (tennisClub.TennisCourts==null)
            {
                return NotFound();
            }

            var bookingToCreate = new Booking()
            {
                DateStart = booking.DateStart,
                DateEnd = booking.DateEnd,
                TennisCourtId = booking.TennisCourtId,
                FirstName = booking.FirstName,
                LastName = booking.LastName,
                PhoneNumber = booking.PhoneNumber,
                //to implement at authentification feature
              /*  PersonId = booking.PersonId*/
            };
            var tennisCourt = _context.TennisCourts.Where(tc => tc.Id == booking.TennisCourtId).FirstOrDefault();
            tennisCourt.IsAvailable = false;
            _context.Bookings.Add(bookingToCreate);
            _context.SaveChanges();

            return CreatedAtRoute(
                "GetBooking", new {tennisClubId, id = _context.Bookings.ToList().Last().Id }, bookingToCreate);
        }


       /* [HttpPut]
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
            tennisCourtToUpdate.SurfaceId = tennisCourt.SurfaceId;
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
            tennisCourtFromDb.SurfaceId = tennisCourtToPatch.SurfaceId;
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
       */

    }
    }

