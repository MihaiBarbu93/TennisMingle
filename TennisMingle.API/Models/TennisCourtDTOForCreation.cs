using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Enums;

namespace TennisMingle.API.Models
{
    public class TennisCourtDTOForCreation
    {
        public string Name { get; set; }
        public Surface Surface { get; set; }
        public int Price { get; set; }
    }
}
