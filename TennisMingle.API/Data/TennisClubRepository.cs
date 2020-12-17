using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Entities;
using TennisMingle.API.Interfaces;

namespace TennisMingle.API.Data
{
    public class TennisClubRepository: ITennisClubRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TennisClubRepository(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<TennisClub> GetTenisClubByIdAsync(int tennisClubId)
        {

            try
            {
                return await _context.TennisClubs
                .Include(tc => tc.City)
                .Include(tc => tc.Facilities)
                .Include(tc => tc.TennisCourts)
                .Include(tc => tc.Photos)
                .Include(tc => tc.Users)
                .SingleOrDefaultAsync(tc => tc.Id == tennisClubId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't receive entities: {ex.Message}");
            }
        }

        public async Task<IEnumerable<TennisClub>> GetTennisClubsAsync(int cityId)
        {

            try
            {
                return await _context.TennisClubs
               .Include(tc => tc.City)
               .Include(tc => tc.Facilities)
               .Include(tc => tc.TennisCourts)
               .ThenInclude(tc => tc.Surface)
               .Include(tc => tc.Photos)
               .Include(tc => tc.Users)
               .Where(tc => tc.CityId == cityId)
               .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't receive entity: {ex.Message}");
            }
           
        }

        public async Task<IEnumerable<TennisClub>> GetTennisClubsWithCourtsAvailableAsync(int cityId)
        {

            try
            {
                var result = await _context.TennisClubs
                .Where(tc => tc.CityId == cityId && tc.TennisCourts.Any(tco => tco.IsAvailable == true))
                .Include(tc => tc.TennisCourts)
                .Include(tc => tc.Facilities)
                .Include(tc => tc.Photos)
                .Include(tc => tc.Users)
                .ToListAsync();
                return result;
            } 
            catch (Exception ex)
            {
                throw new Exception($"Couldn't receive entity: {ex.Message}");
            }
            
        }

        public async Task<TennisClub> CreateTennisClubAsync(int cityId, TennisClub tennisClub)
        {

            var city = _context.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                throw new ArgumentNullException($"{nameof(city)} entity must not be null");
            }

            if (tennisClub == null)
            {
                throw new ArgumentNullException($"{nameof(tennisClub)} entity must not be null");
            }

            try
            {
                await _context.TennisClubs.AddAsync(tennisClub);
                return tennisClub;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(tennisClub)} could not be saved: {ex.Message}");
            }
            
        }

        public void DeleteTennisClub(int cityId, int tennisClubId)
        {

            var city = _context.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                throw new ArgumentNullException($"{nameof(city)} entity must not be null");
            }

            var tennisClub = _context.TennisClubs.FirstOrDefault(tc => tc.Id == tennisClubId);

            if (tennisClub == null)
            {
                throw new ArgumentNullException($"{nameof(tennisClub)} entity must not be null");
            }

            try
            {
                _context.TennisClubs.Remove(tennisClub);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(tennisClub)} could not be deleted: {ex.Message}");
            }
        }

        public void UpdateTennisClubAsync(int cityId, int tennisClubId, TennisClub tennisClub)
        {

            var city = _context.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                throw new ArgumentNullException($"{nameof(city)} entity must not be null");
            }

            var tennisClubFromDB = _context.TennisClubs.FirstOrDefault(tc => tc.Id == tennisClubId);

            if (tennisClubFromDB == null)
            {
                throw new ArgumentNullException($"{nameof(tennisClubFromDB)} entity must not be null");
            }

            try
            {
                tennisClubFromDB.Name = tennisClub.Name;
                tennisClubFromDB.Address = tennisClub.Address;
                tennisClubFromDB.PhoneNumber = tennisClub.PhoneNumber;
                tennisClubFromDB.Description = tennisClub.Description;
                tennisClubFromDB.Schedule = tennisClub.Schedule;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(tennisClubFromDB)} could not be updated: {ex.Message}");
            }   
        }

        /*public void PartiallyUpdateTennisClub(int tennisClubId, TennisClub tennisClubFromDB)
        {

            tennisClubFromDB = _context.TennisClubs.FirstOrDefault(tc => tc.Id == tennisClubId);

            if (tennisClubFromDB == null)
            {
                throw new ArgumentNullException($"{nameof(tennisClubFromDB)} entity must not be null");
            }      
        }*/

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public int GetIdForCreatedTennisClub()
        {
           return _context.TennisClubs.LastAsync().Id;
        }

        // public async Task<IEnumerable<Facility>> GetFacilitiesAsync(int cityId) {

        //     return await _context.TennisClubs.
        //                 Where()
        // }

    }
    
}
