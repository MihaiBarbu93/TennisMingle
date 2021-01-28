using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.DTOs
{
    public class BookingDto
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int TennisCourtId { get; set; }

#nullable enable
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
