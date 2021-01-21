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
        Task<IEnumerable<BookingUpdateDto>> GetBookingsByClubAsync(int clubId);
        Task<IEnumerable<BookingUpdateDto>> GetBookingsByUserAsync(int userId);

        Task<Booking> GetBookingAsync(int id);

        void Book(Booking booking);

        void UpdateBooking(BookingUpdateDto bookingUpdateDto);

        Task<bool> SaveAllAsync();
        Task<bool> CheckAvailability(BookingDto booking, int tennisClubId);

        Task<Booking> GetLastBooking();

        void DeleteBooking(int bookingId);
    }
}
