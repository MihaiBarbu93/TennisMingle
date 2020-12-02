using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.DTOs
{
    public class MemberUpdateDto
    {
        public string Bio { get; set; }
        public int TennisClubId { get; set; }
    }
}
