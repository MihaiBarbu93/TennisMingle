using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TennisMingle.API.Models;

namespace TennisMingle.API.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/tennisclubs/{tennisClubId}/persons")]
    public class CoachController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CoachController(AppDbContext context)
        {
            _context = context;        
        }


        /// <summary>
        /// This GET method returns all the persons from our tennis community
        /// </summary>
        /// 

        [Route("/api/persons")]
        public IActionResult GetAllPersons()
        {
            var persons = _context.Persons.Select(p => p);

            if (persons == null)
            {
                return NotFound();
            }

            return Ok(persons);
        }

        /// <summary>
        /// This GET method returns all the coaches from a club
        /// </summary>
        [HttpGet]
        public IActionResult GetPersons(int cityId, int tennisClubId)
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

            var persons = _context.Persons.Where(p => p.TennisClubId == tennisClubId);

            if (persons == null)
            {
                return NotFound();
            }


            return Ok(persons.ToList());
        }

        /// <summary>
        /// This GET method returns a person from a club with a specific id 
        /// </summary>
        [HttpGet]
        [Route("{id}", Name = "GetPerson")]
        public IActionResult GetPerson(int cityId, int tennisClubId, int id)
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

            var persons = _context.Persons.Where(p => p.TennisClubId == tennisClubId);

            if (persons == null)
            {
                return NotFound();
            }

            return Ok(persons.Where(p=> p.Id == id));
        }

        /// <summary>
        /// This POST method creates a person which is added to a club
        /// </summary>
        [HttpPost]
        public IActionResult CreatePerson(int cityId, int tennisClubId,
            [FromBody] Person person)
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

            var personToCreate = new Person()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Bio = person.Bio,
                TennisClubId = tennisClubId,
                TennisClub = tennisClub,
                Photo = person.Photo,
                Type = person.Type
            };

            _context.Persons.Add(personToCreate);
            _context.SaveChanges();

            return CreatedAtRoute(
                "GetPerson", new { cityId, tennisClubId, id = _context.Persons.ToList().Last().Id }, personToCreate);
        }

        /// <summary>
        /// This PUT method is replacing all the properties of a person
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateCoach(int cityId, int tennisClubId, int id,
            [FromBody] Person person)
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

            var personToUpdate = (from p in _context.Persons
                             where p.Id == id
                             select p).SingleOrDefault();

            personToUpdate.FirstName = person.FirstName;
            personToUpdate.LastName = person.LastName;
            personToUpdate.Bio = person.Bio;
            personToUpdate.TennisClubId = tennisClubId;
            personToUpdate.Photo = person.Photo;
            personToUpdate.Type = person.Type;

            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// This PATCH method is replacing only one property of a person
        /// </summary>
        [HttpPatch]
        [Route("{id}")]

        public IActionResult PartiallyUpdateCoach(int cityId, int tennisClubId, int id,
            [FromBody] JsonPatchDocument<Person> patchDoc)
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
            
            var personFromDb = (from p in _context.Persons
                                where p.Id == id
                                select p).SingleOrDefault();
            if (personFromDb == null) 
            {
                return NotFound();
            }
            var personToPatch = personFromDb;

            patchDoc.ApplyTo(personToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            personFromDb.FirstName = personToPatch.FirstName ;
            personFromDb.LastName = personToPatch.LastName;
            personFromDb.Bio = personToPatch.Bio;
            personFromDb.TennisClubId = personToPatch.TennisClubId;
            personFromDb.Photo = personToPatch.Photo;
            personFromDb.Type = personToPatch.Type;

            _context.SaveChanges();

            return NoContent();

        }

        /// <summary>
        /// This DELETE method removes a person from a club with a specific id 
        /// </summary>
        [HttpDelete]
        [Route("{id}")]

        public IActionResult DeleteCoach(int cityId, int tennisClubId, int id)
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

            var personToDelete = (from p in _context.Persons
                                where p.Id == id
                                select p).SingleOrDefault();
            if (personToDelete == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(personToDelete);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
