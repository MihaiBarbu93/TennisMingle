﻿using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Entities;
using TennisMingle.API.Enums;
using TennisMingle.API.Helpers;

namespace TennisMingle.API.Entities
{
    public class TennisClub
    {

        /// <summary>
        /// Id of the tennis club
        /// </summary>
        
        public int Id { get; set; }

        /// <summary>
        /// Name of the tennis club 
        /// </summary>
        [Required(ErrorMessage = "You should provide a name value")]
        [MaxLength(50)]
        public string Name { get; set; }

    
        /// <summary>
        /// The tennis club phone number
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        public City City { get; set; }

        public int CityId { get; set; }
        public string Address { get; set; }

        public Point Location { get; set; }

        /// <summary>
        /// The tennis club description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The tennis club schedule
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Schedule { get; set; }

        /// <summary>
        /// The price of the tennis court
        /// </summary>
        [Required]
        public int Price { get; set; }

        /// <summary>
        /// The uploaded tennis club image
        /// </summary>
        /// 
        [NotMapped]
        public double GeoLat { get; set; }
        [NotMapped]
        public double GeoLong { get; set; }
        public ICollection<TennisCourt> TennisCourts { get; set; }

        public ICollection<Facility> Facilities { get; set; }
#nullable enable
        public ICollection<Photo>? Photos { get; set; }

        public ICollection<AppUser>? Users { get; set; }

       

    }
}
