using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Data;
using TennisMingle.API.Entities;
using TennisMingle.API.Interfaces;

namespace TennisMingle.API.Services
{
    public class SurfaceService : ISurfaceService
    {
        private readonly AppDbContext _context;

        public SurfaceService(AppDbContext _context)
        {
            this._context = _context;
        }
        public void UpdateSurface(int tennisCourtId, Surface surface)
        {
            var tennisCourt = _context.TennisCourts.FirstOrDefault(tc => tc.Id == tennisCourtId);

            tennisCourt.Surface.SurfaceType = surface.SurfaceType;

        }
    }
}
