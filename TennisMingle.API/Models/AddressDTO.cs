using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.Models
{
    public class AddressDTO
    {
        public int Id { get; set; }

        public string Address { get; set; }
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public CityDTO City { get; set; }
    }
}
