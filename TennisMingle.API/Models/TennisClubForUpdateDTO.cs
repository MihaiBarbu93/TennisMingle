using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Enums;

namespace TennisMingle.API.Models
{
    public class TennisClubForUpdateDTO
    {

# nullable enable
        [Required(ErrorMessage ="You should provide a name value")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public List<int> Prices { get; set; }
        [Required]
        [MaxLength(50)]
        public string Schedule { get; set; }
        public string? Image { get; set; }

#nullable disable
        public ICollection<TennisCourtDTO> TennisCourts { get; set; }

        public ICollection<CoachDTO> Coaches { get; set; }

        public ICollection<Surface> Surfaces { get; set; }

        public ICollection<Facilities> Facilities { get; set; }
    }
}
