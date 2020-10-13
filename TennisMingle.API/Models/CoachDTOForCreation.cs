using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.Models
{
    public class CoachDTOForCreation
    {
# nullable enable
        [Required(ErrorMessage = "You should provide a name value")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Bio { get; set; }
        public string? Photo { get; set; }
    }
}
