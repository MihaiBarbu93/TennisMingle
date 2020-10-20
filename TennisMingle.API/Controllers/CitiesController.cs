/*using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        /// <summary>
        /// This GET method returns all the Cities from the DataBase 
        /// </summary>
        [HttpGet]
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }

        /// <summary>
        /// This GET method returns a City with a specific id from the DataBase 
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetCity(int id) 
        {
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if (cityToReturn == null) 
            {
                return NotFound();
            }
            return Ok(cityToReturn);
        }
    }
}
*/