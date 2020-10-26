using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Enums;

namespace TennisMingle.API.Models
{
    public class Surface
    {
        public int Id { get; set; }
        [Required]
        public Surfaces SurfaceType { get; set; }

        public TennisCourt TennisCourt { get; set; }
    }
}
