using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.Models
{
    public class Booking
    {
/*        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        
        public int TennisCourtId { get; set; }
        [ForeignKey("TennisCourtId")]
        public virtual TennisCourt TennisCourt { get; set; }
        [NotMapped]
        public int Duration { get; set; }
        public int? PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
