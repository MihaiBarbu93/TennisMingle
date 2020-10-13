using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Enums;

namespace TennisMingle.API.Models
{
    public class TennisCourtDTO
    {
        /// <summary>
        /// Id of the tennis court
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the tennis court
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The surface type of the tennis court
        /// </summary>
        public Surface Surface { get; set; }

        /// <summary>
        /// The price of the tennis court
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// The availability of the tennis court
        /// </summary>
        public bool IsAvailable { get; set; } = true;
    }
}
