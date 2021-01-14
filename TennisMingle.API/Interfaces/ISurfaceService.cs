using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Entities;
using TennisMingle.API.Enums;

namespace TennisMingle.API.Interfaces
{
    public interface ISurfaceService
    {
        void UpdateSurface(Surface surface);
        Task<List<string>> GetSurfaces(int cityId);
    }
}
