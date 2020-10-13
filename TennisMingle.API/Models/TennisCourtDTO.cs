using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Enums;

namespace TennisMingle.API.Models
{
    public class TennisCourtDTO
    {

#nullable enable
        public int Id { get; set; }
        [Required(ErrorMessage = "You should provide a name value")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public Surface Surface { get; set; }
        [Required]
        [MaxLength(50)]
        public int Price { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
