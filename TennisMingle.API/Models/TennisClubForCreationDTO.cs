using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Enums;

namespace TennisMingle.API.Models
{
    public class TennisClubForCreationDTO
    {
        public string Name { get; set; }

        public ICollection<TennisCourtDTO> TennisCourts { get; set; }

        public ICollection<CoachDTO> Coaches { get; set; };

        public ICollection<Surface> Surfaces { get; set; }

        public ICollection<Facilities> Facilities { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public List<int> Prices { get; set; }
        public string Schedule { get; set; }
        public string Image { get; set; }
    }
}
