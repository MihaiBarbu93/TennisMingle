using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.Models
{
    public class CoachDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Photo { get; set; }
        public ICollection<TennisClubDTO> TennisClubs { get; set; } = new List<TennisClubDTO>();

    }
}
