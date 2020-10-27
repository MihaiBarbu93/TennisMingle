﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace TennisMingle.API.Models
{
    public class City
    {
        /// <summary>
        /// Id of the city 
        /// </summary>
  
        public int Id { get; set; }

        [Required(ErrorMessage = "You should provide a name value")]
        [MaxLength(50)]

        /// <summary>
        /// City Name 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Collection of tennis clubs from a city 
        /// </summary>
        public ICollection<TennisClubAddress>? TennisClubAddresses { get; set; }
    }
}