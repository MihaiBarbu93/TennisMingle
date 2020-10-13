using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.Models
{
    public class CoachDTO
    {
        /// <summary>
        /// Id of the coach
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Coach's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Coach's informations
        /// </summary>
        public string Bio { get; set; }

        /// <summary>
        /// The name of the uploaded photo 
        /// </summary>
        public string Photo { get; set; }

    }
}
