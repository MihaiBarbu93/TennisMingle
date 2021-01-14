using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Enums;
using TennisMingle.API.Entities;

namespace TennisMingle.WEB.Models
{
    public class EntityViewModel
    {
        public TennisClub TennisClub { get; set; }
        public HashSet<City> Cities { get; set; } = new HashSet<City>();

        public HashSet<Facility> Facilities { get; set; } = new HashSet<Facility>();

        public HashSet<AppUser> Persons { get; set; } = new HashSet<AppUser>();
        public HashSet<Surface> Surfaces { get; set; } = new HashSet<Surface>();
        public HashSet<TennisClub> TennisClubs { get; set; } = new HashSet<TennisClub>();
        public HashSet<TennisCourt> TennisCourts { get; set; } = new HashSet<TennisCourt>();
        public HashSet<Booking> Bookings { get; set; } = new HashSet<Booking>();


       
    }
}
