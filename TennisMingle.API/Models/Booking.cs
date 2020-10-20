using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime date_start { get; set; }
        public DateTime date_end { get; set; }

        public int TennisCourtId { get; set; }

        [ForeignKey("TennisCourtId")]
        public TennisCourtDTO TennisCourt { get; set; }

        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public PersonDTO Person { get; set; }
    }
}
