using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Entities;
using TennisMingle.API.Interfaces;

namespace TennisMingle.API.Data
{
    public class TennisCourtRepository : ITennisCourtRepository
    {

        public Task<TennisCourt> CreateTennisClubAsync(int tennisClubId, TennisCourt tennisCourt)
        {
            throw new NotImplementedException();
        }

        public Task<TennisCourt> DeleteTennisCourtAsync(int tennisCourtId)
        {
            throw new NotImplementedException();
        }

        public Task<TennisCourt> GetTennisCourtByIdAsync(int tennisCourtId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TennisCourt>> GetTennisCourtsAsync(int tennisClubId)
        {
            throw new NotImplementedException();
        }

        public Task<TennisCourt> UpdateTennisCourtAsync(int tennisCourtId, TennisCourt tennisCourt)
        {
            throw new NotImplementedException();
        }
    }
}
