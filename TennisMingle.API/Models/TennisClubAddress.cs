using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.Models
{
    public class TennisClubAddress
    {
        public int Id { get; set; }

        public string Address { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public TennisClub? TennisClub { get; set; }
    }
}
