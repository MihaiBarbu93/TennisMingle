using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.DTOs;
using TennisMingle.API.Entities;

namespace TennisMingle.API.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetBookingsByClubAsync(int clubId);
        Task<IEnumerable<BookingDto>> GetBookingsByUserAsync(int userId);

        Task<Booking> GetBookingAsync(int id);

        void Book(Booking booking, int userId, int clubId);

        Task<bool> SaveAllAsync();
        Task<bool> AlreadyBooked(DateTime dateStart, DateTime dateEnd);
    }
}
