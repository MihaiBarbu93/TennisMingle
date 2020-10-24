using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Models;

namespace TennisMingle.WEB.Models
{
    public class EntityViewModel
    {
        public List<AddressDTO> Addresses { get; set; }
        public List<CityDTO> Cities  { get; set; }

        public List<Facility> Facilities { get; set; }

        public List <PersonDTO> Persons { get; set; }
        public List<Surface> Surfaces { get; set; }
        public List<TennisClubDTO> TennisClubs { get; set; }
        public List<TennisCourtDTO> TennisCourts { get; set; }

    }
}
