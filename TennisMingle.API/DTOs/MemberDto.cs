using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Entities;
using TennisMingle.API.Enums;

namespace TennisMingle.API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public City City { get; set; }

        public string PhotoUrl { get; set; }
        //public string Bio { get; set; }
        //public PhotoDto Photo { get; set; }
        //public TennisClub TennisClub { get; set; }
        //public int PersonTypeId { get; set; }
        public ICollection<string> Roles { get; set; }
        public ICollection<Booking> Bookings { get; set; }

    }
}
