using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Entities;

namespace TennisMingle.API.Interfaces
{
    public interface IFacilityService
    {
        void AddFacility(Facility facility, int clubId);
        void DeleteFacility(int facilityId);

    }
}
