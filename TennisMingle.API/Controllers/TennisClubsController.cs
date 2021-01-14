using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Data;
using TennisMingle.API.Entities;
using TennisMingle.API.Enums;
using TennisMingle.API.Interfaces;

namespace TennisMingle.API.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/tennisclubs")]
    public class TennisClubController : ControllerBase
    {
        private AppDbContext _context;
        private readonly ITennisClubRepository _tennisClubRepository;
        private readonly IFacilityService _facilityService;

        public TennisClubController(AppDbContext context, ITennisClubRepository tennisClubRepository, IFacilityService facilityService)
        {
            _facilityService = facilityService;
            _context = context;
            _tennisClubRepository = tennisClubRepository;
        }
        /// <summary>
        /// This GET method returns all the tennis clubs from a city
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TennisClub>>> GetTennisClubs(int cityId)
        {
            var tennisClubs = await _tennisClubRepository.GetTennisClubsAsync(cityId);

            return Ok(tennisClubs);
        }

        [HttpGet("withcourtsavailable")]
        public async Task<ActionResult<IEnumerable<TennisClub>>> GetTennisClubsWithCourts(int cityId)
        {
            var tennisClubs = await _tennisClubRepository.GetTennisClubsWithCourtsAvailableAsync(cityId);

            return Ok(tennisClubs);
        }

        /// <summary>
        /// This GET method returns a tennis club with a specific id 
        /// </summary>
        [HttpGet("{tennisClubId}")]
        public async Task<ActionResult<TennisClub>> GetTennisClub(int tennisClubId)
        {
            var tennisClub = await _tennisClubRepository.GetTenisClubByIdAsync(tennisClubId);

            return Ok(tennisClub);
        }

        /// <summary>
        /// This POST method creates a tennis club which is added to a city
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<TennisClub>> CreateTennisClub(int cityId, [FromBody] TennisClub tennisClub)
        {

            var tennisClubToAdd = new TennisClub
            {
                Name = tennisClub.Name,
                PhoneNumber = tennisClub.PhoneNumber,
                Description = tennisClub.Description,
                Schedule = tennisClub.Schedule,
                /*Image = tennisClub.Image*/
            };

            await _tennisClubRepository.CreateTennisClubAsync(cityId, tennisClubToAdd);

            if (await _tennisClubRepository.SaveAllAsync())
            {
                return CreatedAtRoute("GetTennisClub", new { cityId, tennisClubId = _tennisClubRepository.GetIdForCreatedTennisClub() }, tennisClubToAdd);
            }

            return BadRequest("Failed to add tennis club");
        }

        /// <summary>
        /// This PUT method is replacing all the properties of a tennis club
        /// </summary>
        [HttpPut("{tennisClubId}")]
        public async Task<ActionResult> UpdateTennisClub(int cityId, int tennisClubId, TennisClub tennisClub)
        {

            _tennisClubRepository.UpdateTennisClubAsync(cityId, tennisClubId, tennisClub);

            /*            tennisClubFromDB.Image = tennisClub.Image;
            */
            if (await _tennisClubRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update the tennis club");

        }

        /*        /// <summary>
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
        *//*            tennisClubFromDB.Image = tennisClubToPatch.Image;
        *//*
                    _context.SaveChanges();

                    return NoContent();
                }*/

        /// <summary>
        /// This DELETE method removes a tennis club from a city with a specific id 
        /// </summary>
        [HttpDelete("{tennisClubId}")]
        public async Task<ActionResult> DeleteTennisClub(int cityId, int tennisClubId)
        {
            _tennisClubRepository.DeleteTennisClub(cityId, tennisClubId);

            if (await _tennisClubRepository.SaveAllAsync()) return Ok();

            return BadRequest("Problem deleting this tennis club");
        }

        [HttpGet]
        [Route("allfacilities")]
        public async Task<ActionResult<IEnumerable<string>>> getAllFacilities(int cityId)
        {
            return await _facilityService.GetFacilities(cityId);
        }
    }
}
