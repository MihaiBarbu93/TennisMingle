using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Models;

namespace TennisMingle.WEB.Models
{
    public class EntityViewModel
    {
        public TennisClub TennisClub { get; set; }
        public HashSet<TennisClubAddress> Addresses { get; set; }
        public HashSet<City> Cities { get; set; } = new HashSet<City>();

        public HashSet<Facility> Facilities { get; set; }

        public HashSet<Person> Persons { get; set; }
        public HashSet<Surface> Surfaces { get; set; } = new HashSet<Surface>();
        public HashSet<TennisClub> TennisClubs { get; set; }
        public HashSet<TennisCourt> TennisCourts { get; set; }

    }
}
