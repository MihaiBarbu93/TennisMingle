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
        public @string FacilityType { get; set; }
#nullable enable
        public TennisClub? TennisClub { get; set; }

        public int? TennisClubId { get; set; }

    }
}
