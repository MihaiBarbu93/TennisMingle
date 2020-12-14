using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Entities;
using TennisMingle.API.Enums;

namespace TennisMingle.API.Interfaces
{
    public interface IFacilityService
    {
        void AddFacility(Facility facility, int clubId);
        void DeleteFacility(int clubId, int facilityId);
        List<FacilityType> GetFacilities(int cityId);

    }
}
