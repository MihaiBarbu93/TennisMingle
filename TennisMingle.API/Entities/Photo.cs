using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Entities;

namespace TennisMingle.API.Entities
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
#nullable enable
        public TennisClub? TennisClub { get; set; }
        public int? TennisClubId { get; set; }

        public AppUser? Person { get; set; }

        public int? PersonId { get; set; }
    }
}
