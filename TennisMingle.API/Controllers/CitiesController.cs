using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Models;

namespace TennisMingle.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CitiesController(AppDbContext context)
        {
            _context = context;

        }
        /// <summary>
        /// This GET method returns all the Cities from the DataBase 
        /// </summary>
        [HttpGet]
        public IActionResult GetCities()
        {
            return Ok(_context.Cities.ToList());
        }

        /// <summary>
        /// This GET method returns a City with a specific id from the DataBase 
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var cityToReturn =_context.Cities.FirstOrDefault(c => c.Id == id);
            if (cityToReturn == null)
            {
                return NotFound();
            }
            return Ok(cityToReturn);
        }
    }
}
