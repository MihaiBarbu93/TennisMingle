using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.Models
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TennisClubDTO> TennisClubs { get; set; } = new List<TennisClubDTO>();
    }
}
