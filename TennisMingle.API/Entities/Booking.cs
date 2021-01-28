using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int TennisCourtId { get; set; }
        public virtual TennisCourt TennisCourt { get; set; }
        public bool Confirmed { get; set; } = false;

#nullable enable
        public int? UserId { get; set; }
        public AppUser? User { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

    }
}
