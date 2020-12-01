using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Entities;

namespace TennisMingle.API.Interfaces
{
    interface IFacilityService
    {
        Task<Facility> AddFacilityAsync(Facility facility);
        Task<Facility> DeleteFacilityAsync(string facilityId);

    }
}
