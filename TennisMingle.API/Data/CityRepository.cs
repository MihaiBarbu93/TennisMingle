using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.DTOs;
using TennisMingle.API.Entities;
using TennisMingle.API.Interfaces;

namespace TennisMingle.API.Data
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CityRepository(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddCity(City city)
        {
            _context.Cities.Add(city);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {

            return await _context.Cities
                .ToListAsync();
        }
        public async Task<City> GetCityByIdAsync(int id)
        {
            return await _context.Cities
                .Include(c => c.TennisClubs)    
                .SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task<City> GetCityByNameAsync(string name)
        {
            return await _context.Cities
                .Include(c => c.TennisClubs)
                .SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task<bool> CityExists(string name)
        {
            return await _context.Cities.AnyAsync(c => c.Name == name);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
