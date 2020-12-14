using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Data;
using TennisMingle.API.Entities;
using TennisMingle.API.Enums;
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
        public void UpdateSurface(Surface surface)
        {
            _context.Entry(surface).State = EntityState.Modified;

        }

        public async Task<List<string>> GetSurfaces(int cityId)
        {

            var tennisCourts = _context.TennisClubs
                .Where(tc => tc.CityId == cityId)
                .SelectMany(tc => tc.TennisCourts)
                .Include(tco => tco.Surface);

            return await tennisCourts
             .Select(tco => tco.Surface.SurfaceType.ToString())
             .Distinct()
             .ToListAsync();

        }
    }
}
