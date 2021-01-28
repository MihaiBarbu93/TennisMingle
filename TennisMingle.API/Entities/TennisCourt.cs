using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Enums;

namespace TennisMingle.API.Entities
{
    public class TennisCourt
    {
        /// <summary>
        /// Id of the tennis court
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the tennis court
        /// </summary>
        [Required(ErrorMessage = "You should provide a name value")]
        [MaxLength(50)]
        public string Name { get; set; }

        public Surface Surface { get; set; }

        public int SurfaceId { get; set; }

        /// <summary>
        /// The surface type of the tennis court
        /// </summary>
        public int TennisClubId { get; set; }

        public TennisClub TennisClub { get; set; }

    }
}
