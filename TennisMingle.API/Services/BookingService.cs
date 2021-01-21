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

        //to modify
        public async Task<bool> CheckAvailability(BookingDto booking, int tennisClubId)
        {
            return await _context.Bookings
                .Where(b => b.TennisCourt.TennisClubId == tennisClubId)
                .AnyAsync(b => (booking.DateStart < b.DateStart || booking.DateStart > b.DateEnd) &&
                               (booking.DateEnd > b.DateStart || booking.DateEnd < b.DateEnd) && 
                               b.TennisCourt.IsAvailable == true);
        }

        public void Book(Booking booking)
        {
             _context.Bookings.Add(booking);
        }

        public async Task<Booking> GetBookingAsync(int id)
        {
            return await _context.Bookings
               .Include(b => b.TennisCourt.TennisClub)
               .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<BookingUpdateDto>> GetBookingsByClubAsync(int clubId)
        {
            return await _context.Bookings
                .Include(b=>b.TennisCourt.TennisClub)
                .Where(b=>b.TennisCourt.TennisClubId==clubId)
                .ProjectTo<BookingUpdateDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<BookingUpdateDto>> GetBookingsByUserAsync(int userId)
        {
            return await _context.Bookings
                .Include(b => b.TennisCourt.TennisClub)
                .Where(b => b.UserId==userId)
                .ProjectTo<BookingUpdateDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateBooking(BookingUpdateDto bookingDto)
        {
            _context.Entry(bookingDto).State = EntityState.Modified;
        }

        public async Task<Booking> GetLastBooking()
        {
            return await _context.Bookings.OrderByDescending(t => t.Id).FirstAsync(); ;
        }

        public void DeleteBooking(int bookingId)
        {

            var bookingToDelete = _context.Bookings.Find(bookingId);

            _context.Bookings.Remove(bookingToDelete);

        }
    }
}
