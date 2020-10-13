using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Enums;

namespace TennisMingle.API.Models
{
    public class TennisCourtDTOForUpdate
    {
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
    }
}
