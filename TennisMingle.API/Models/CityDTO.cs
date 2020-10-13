using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.Models
{
    public class CityDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You should provide a name value")]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<TennisClubDTO> TennisClubs { get; set; } = new List<TennisClubDTO>();

    }
}
