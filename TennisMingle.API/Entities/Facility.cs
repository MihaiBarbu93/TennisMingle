using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Enums;

namespace TennisMingle.API.Entities
{
    [Table("Facilities")]
    public class Facility
    {
        public int Id { get; set; }
        public FacilityType FacilityType { get; set; }
        public int TennisClubId { get; set; }
        public TennisClub TennisClub { get; set; }
    }
}
