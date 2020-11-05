using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Enums;

namespace TennisMingle.API.Models
{
    public class PersonType
    {
        public int Id { get; set; }
        [Required]
        public PType PersType { get; set; }

        public Person Person { get; set; }
    }
}
