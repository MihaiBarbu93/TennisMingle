using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Data;
using TennisMingle.API.DTOs;
using TennisMingle.API.Entities;
using TennisMingle.API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace TennisMingle.API.Controllers
{

    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository,
                                 IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _userRepository.GetMembersAsync();

            return Ok(users);
        }
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await _userRepository.GetMemberAsync(username);
        }

        /*[Route("/api/persons")]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetAllPersons()
        {
            var persons = await _personRepository.GetPersonsAsync;

            return Ok(persons);
        }

        /// <summary>
        /// This GET method returns all the coaches from a club
        /// </summary>
        [HttpGet]
        [Route("api/cities/{cityId}/tennisclubs/{tennisClubId}/persons")]
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

            var persons = _context.Persons.Where(p => p.TennisClubId == tennisClubId).Include(p => p.PersonType);

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
        [Route("api/cities/{cityId}/tennisclubs/{tennisClubId}/persons/{id}", Name = "GetPerson")]
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

            var persons = _context.Persons.Where(p => p.TennisClubId == tennisClubId).Include(p => p.PersonType);

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
        [Route("api/cities/{cityId}/tennisclubs/{tennisClubId}/persons")]
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
                PersonType = person.PersonType
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
        [Route("api/cities/{cityId}/tennisclubs/{tennisClubId}/persons/{id}")]
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
            personToUpdate.PersonType = person.PersonType;

            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// This PATCH method is replacing only one property of a person
        /// </summary>
        [HttpPatch]
        [Route("api/cities/{cityId}/tennisclubs/{tennisClubId}/persons/{id}")]

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
            personFromDb.PersonType = personToPatch.PersonType;

            _context.SaveChanges();

            return NoContent();

        }

        /// <summary>
        /// This DELETE method removes a person from a club with a specific id 
        /// </summary>
        [HttpDelete]
        [Route("api/cities/{cityId}/tennisclubs/{tennisClubId}/persons/{id}")]

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
        }*/

    }
}
