using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Enums;

namespace TennisMingle.API.Models
{
    public class TennisClubDTO
    {

        /// <summary>
        /// Id of the tennis club
        /// </summary>
        [Required(ErrorMessage = "You should provide a name value")]
        [MaxLength(50)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the tennis club 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The tennis club adress
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        /// <summary>
        /// The tennis club phone number
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The tennis club description
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        /// <summary>
        /// The tennis club prices
        /// </summary>
        public List<int> Prices { get; set; }

        // <summary>
        /// The tennis club schedule
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Schedule { get; set; }

        /// <summary>
        /// The uploaded tennis club image
        /// </summary>
        public string? Image { get; set; }

#nullable disable

        /// <summary>
        /// The collection of the tennis club courts 
        /// </summary>
        public ICollection<TennisCourtDTO> TennisCourts { get; set; }

        /// <summary>
        /// The collection of the tennis club coaches
        /// </summary>
        public ICollection<CoachDTO> Coaches { get; set; }

        /// <summary>
        /// The collection of the tennis club courts surfaces 
        /// </summary>
        public ICollection<Surface> Surfaces { get; set; }

        /// <summary>
        /// The collection of the tennis club facilities 
        /// </summary>
        public ICollection<Facilities> Facilities { get; set; }

    }
}
