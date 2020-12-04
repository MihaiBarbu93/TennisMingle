using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Entities;

namespace TennisMingle.API.Interfaces
{
    public interface ITennisCourtRepository
    {
        
        Task<IEnumerable<TennisCourt>> GetTennisCourtsAsync(int tennisClubId);
        Task<TennisCourt> GetTennisCourtByIdAsync(int tennisCourtId);
        Task<TennisCourt> CreateTennisClubAsync(int tennisClubId, TennisCourt tennisCourt);
        Task<TennisCourt> UpdateTennisCourtAsync(int tennisCourtId, TennisCourt tennisCourt);
        Task<TennisCourt> DeleteTennisCourtAsync(int tennisCourtId);


    }
}
