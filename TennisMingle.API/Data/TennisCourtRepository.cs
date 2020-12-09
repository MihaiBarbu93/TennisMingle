using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Entities;
using TennisMingle.API.Interfaces;

namespace TennisMingle.API.Data
{
    public class TennisCourtRepository : ITennisCourtRepository
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TennisCourtRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TennisCourt> GetTennisCourtByIdAsync(int tennisCourtId)
        {
            return await _context.TennisCourts
                .Include(tc => tc.Surface)
                .Include(tc => tc.TennisClub)
                .SingleOrDefaultAsync(tc => tc.Id == tennisCourtId);
        }

        public async Task<IEnumerable<TennisCourt>> GetTennisCourtsAsync(int tennisClubId)
        {
              return await _context.TennisCourts
                .Where(tc => tc.TennisClubId == tennisClubId)
                .Include(tc => tc.Surface)
                .Include(tc => tc.TennisClub)
                .ToListAsync();

/*            return await Task.FromResult(_context.TennisClubs
                .Include(tc => tc.TennisCourts)
                .SingleOrDefault(tc => tc.Id == tennisClubId)
                .TennisCourts
                .ToList());*/

        }

        public void CreateTennisCourt(int tennisClubId, TennisCourt tennisCourt)
        {
            var tennisClub = _context
                .TennisClubs
                .Include(tc => tc.TennisCourts)
                .SingleOrDefault(tc => tc.Id == tennisClubId);

            var newTennisCourt = new TennisCourt()
            {
                Name = tennisCourt.Name,
                SurfaceId = tennisCourt.SurfaceId,
                TennisClubId = tennisClubId
            };

            _context.TennisCourts.Add(newTennisCourt);

        }

        public void UpdateTennisCourt(TennisCourt tennisCourt)
        {

            _context.Entry(tennisCourt).State = EntityState.Modified;

        }

        public void DeleteTennisCourt(int tennisCourtId)
        {
            var tennisCourtToDelete =_context.TennisCourts.SingleOrDefault(tc => tc.Id == tennisCourtId);

            _context.TennisCourts.Remove(tennisCourtToDelete);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<TennisCourt> GetLastTennisCourt()
        {
            return await _context.TennisCourts.OrderByDescending(t => t.Id).FirstAsync(); ;
        }

        public async Task<TennisCourt> GetTennisCourtAvailableAsync(int tennisClubId)
        {
            return await _context.TennisCourts.Where(tc => tc.TennisClubId == tennisClubId).FirstOrDefaultAsync(tc => tc.IsAvailable == true);
        }
    }
}
