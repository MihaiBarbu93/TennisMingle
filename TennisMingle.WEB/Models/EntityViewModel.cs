using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Models;

namespace TennisMingle.WEB.Models
{
    public class EntityViewModel
    {
        public List<TennisClubAddress> Addresses { get; set; }
        public List<City> Cities  { get; set; }

        public List<Facility> Facilities { get; set; }

        public List <Person> Persons { get; set; }
        public List<Surface> Surfaces { get; set; }
        public List<TennisClub> TennisClubs { get; set; }
        public List<TennisCourt> TennisCourts { get; set; }

    }
}
