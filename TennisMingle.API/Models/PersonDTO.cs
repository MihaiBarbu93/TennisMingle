using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Enums;

namespace TennisMingle.API.Models
{
    public class PersonDTO
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string Photo { get; set; }
        public int TennisClubId { get; set; }
        [ForeignKey("TennisClubId")]
        public TennisClubDTO TennisClub { get; set; }

        [Required]
        public PersonType Type { get; set; }

    }
}
