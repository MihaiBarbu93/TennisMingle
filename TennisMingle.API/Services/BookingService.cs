using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Data;
using TennisMingle.API.DTOs;
using TennisMingle.API.Entities;
using TennisMingle.API.Interfaces;

namespace TennisMingle.API.Services
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public BookingService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        //to implement
        public async Task<bool> AlreadyBooked(DateTime dateStart, DateTime dateEnd)
        {
            return await _context.Bookings.AnyAsync();
        }

        public void Book(Booking booking, int userId, int clubId)
        {
            throw new NotImplementedException();
        }

        public async Task<Booking> GetBookingAsync(int id)
        {
            return await _context.Bookings
               .Include(b => b.TennisCourt.TennisClub)
               .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<BookingDto>> GetBookingsByClubAsync(int clubId)
        {
            return await _context.Bookings
                .Include(b=>b.TennisCourt.TennisClub)
                .Where(b=>b.TennisCourt.TennisClubId==clubId)
                .ProjectTo<BookingDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<BookingDto>> GetBookingsByUserAsync(int userId)
        {
            return await _context.Bookings
                .Include(b => b.TennisCourt.TennisClub)
                .Where(b => b.UserId==userId)
                .ProjectTo<BookingDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
