using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.Models
{
    public class CoachDTOForCreation
    {
        /// <summary>
        /// Coach's name
        /// </summary>
        [Required(ErrorMessage = "You should provide a name value")]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Coach's informations
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Bio { get; set; }

        /// <summary>
        /// The name of the uploaded photo 
        /// </summary>
        public string? Photo { get; set; }
    }
}
