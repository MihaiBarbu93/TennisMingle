using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        public int Id { get; set; }

        /// <summary>
        /// Name of the tennis club 
        /// </summary>
        [Required(ErrorMessage = "You should provide a name value")]
        [MaxLength(50)]
        public string Name { get; set; }

    
        /// <summary>
        /// The tennis club phone number
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The tennis club adress
        /// </summary>

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public CityDTO City { get; set; }

        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public AddressDTO Address { get; set; }




        /// <summary>
        /// The tennis club description
        /// </summary>
        public string Description { get; set; }

        public List<Facilities> Facilities { get; set; }

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



    }
}
