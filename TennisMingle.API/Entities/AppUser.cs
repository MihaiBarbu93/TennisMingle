using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Entities;
using TennisMingle.API.Enums;

namespace TennisMingle.API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public City City { get; set; }
        public string Country { get; set; }

        public string Bio { get; set; }
        public Photo Photo { get; set; }

        public UserType UserType { get; set; }
        public ICollection<Booking> Bookings { get; set; }
#nullable enable
        public int? TennisClubId { get; set; }
        public TennisClub? TennisClub { get; set; }

    }
}
