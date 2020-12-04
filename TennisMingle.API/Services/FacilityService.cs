﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Data;
using TennisMingle.API.Entities;
using TennisMingle.API.Interfaces;

namespace TennisMingle.API.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public FacilityService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public void AddFacility(Facility facility, int clubId)
        {
            _context.TennisClubs.Find(clubId).Facilities.Add(facility);

        }

        public void DeleteFacility(int clubId, int facilityId)
        {
            
            var facilityToDelete = _context.Facilities.Find(facilityId);
                                       
            _context.Facilities.Remove(facilityToDelete);

        }

/*        private async Task<bool> FacilityExists(Facility facility, int clubId)
        {
            return await _context.TennisClubs.Find(clubId).Facilities.AnyAsync(f => f.FacilityType == facility.FacilityType);
        }*/
    }
}
