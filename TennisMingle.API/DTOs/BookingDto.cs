using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
