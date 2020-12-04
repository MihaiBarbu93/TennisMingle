using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Data;
using TennisMingle.API.Entities;
using TennisMingle.API.Services;

namespace TennisMingle.API.Controllers
{
    [Route("api/tennisclubs/{tennisClubId}/tenniscourts")]
    public class TennisCourtController : BaseApiController
    {
        private readonly SurfaceService _surfaceService;
        private readonly TennisCourtRepository _tennisCourtRepository;
        private readonly IMapper _mapper;

        public TennisCourtController(SurfaceService surfaceService,
            TennisCourtRepository tennisCourtRepository, IMapper mapper)
        {
            _surfaceService = surfaceService;
            _tennisCourtRepository = tennisCourtRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// This GET method returns all the tennis courts from a club 
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TennisCourt>>> GetTennisCourts(int tennisClubId)
        {
            return  Ok(await _tennisCourtRepository.GetTennisCourtsAsync(tennisClubId));
        }

        /// <summary>
        /// This GET method returns a tennis court with a specific id 
        /// </summary>
        [HttpGet]
        [Route("{tennisCourtId}", Name = "GetTennisCourt")]
        public async Task<ActionResult<TennisCourt>> GetTennisCourt(int tennisCourtId)
        {
            return Ok(await _tennisCourtRepository.GetTennisCourtByIdAsync(tennisCourtId));
        }

        /// <summary>
        /// This POST method creates a tennis court which is added to a club
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> CreateTennisCourt(int tennisClubId, TennisCourt tennisCourt)
        {

            var newTennisCourt = _tennisCourtRepository.CreateTennisCourt(tennisClubId, tennisCourt);

            if (await _tennisCourtRepository.SaveAllAsync())
            {
                return CreatedAtRoute(
                "GetTennisCourt", new { tennisCourtId = newTennisCourt.Id}, newTennisCourt);
            }

            return BadRequest("Unable to add tennis court");
        }

        /// <summary>
        /// This PUT method is replacing all the properties of a tennis court
        /// </summary>
        [HttpPut]
        [Route("{tennisCourtId}")]
        public async Task<ActionResult> UpdateTennisCourt(int tennisCourtId,
            TennisCourtForUpdateDto tennisCourtForUpdateDto)
        {
            var tennisCourt = await _tennisCourtRepository.GetTennisCourtByIdAsync(tennisCourtId);

            _mapper.Map(tennisCourtForUpdateDto, tennisCourt);


            _tennisCourtRepository.UpdateTennisCourt(tennisCourt);


            if (await _tennisCourtRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update tennis court");

        }

        /// <summary>
        /// This DELETE method removes a tennis court from a club with a specific id 
        /// </summary>
        [HttpDelete]
        [Route("{tennisCourtId}")]

        public async Task<ActionResult> DeleteTennisCourt(int tennisCourtId)
        {

            _tennisCourtRepository.DeleteTennisCourt(tennisCourtId);

            if (await _tennisCourtRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update tennis court");
        }

        public void UpdateSurface(int tennisCourtId, Surface surface)
        {
            _surfaceService.UpdateSurface(tennisCourtId, surface);
        }

    }
}

