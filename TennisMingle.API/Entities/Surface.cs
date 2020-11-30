using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Enums;

namespace TennisMingle.API.Entities
{
    public class Surface
    {
        public int Id { get; set; }
        [Required]
        public SurfaceType SurfaceType { get; set; }

        public List<TennisCourt> TennisCourts { get; set; }
    }
}
