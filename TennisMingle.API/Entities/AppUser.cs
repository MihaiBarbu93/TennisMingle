using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using TennisMingle.API.Enums;

namespace TennisMingle.API.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public DateTime DateOfBirth { get; set; }
        
        public string Bio { get; set; }
        public Photo Photo { get; set; }

        public UserType UserType { get; set; }
        public ICollection<Booking> Bookings { get; set; }
#nullable enable
        public City? City { get; set; }
        public int? CityId { get; set; }
        public int? TennisClubId { get; set; }
        public TennisClub? TennisClub { get; set; }

        public ICollection<AppUserRole> UserRoles { get; set; }

    }
}
