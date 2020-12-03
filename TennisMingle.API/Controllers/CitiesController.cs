using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Data;
using TennisMingle.API.Entities;
using TennisMingle.API.Interfaces;

namespace TennisMingle.API.Controllers
{
    public class CitiesController : BaseApiController
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityRepository cityRepository,
                                 IMapper mapper)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _cityRepository.GetCitiesAsync();

            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id)
        {
            var cities = await _cityRepository.GetCityByIdAsync(id);

            return Ok(cities);
        }

        [HttpPost]
        public async Task<ActionResult<City>> AddCity(City city) 
        {
            if (await _cityRepository.CityExists(city.Name)) return BadRequest("City already added");

            _cityRepository.AddCity(city);
            await _cityRepository.SaveAllAsync();
            return new City
            {
                Name = city.Name,
            };

        }
    }
}
