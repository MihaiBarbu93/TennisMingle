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
        void CreateTennisCourt(int tennisClubId, TennisCourt tennisCourt);
        void UpdateTennisCourt(TennisCourt tennisCourt);
        void DeleteTennisCourt(int tennisCourtId);
        Task<bool> SaveAllAsync();
        Task<TennisCourt> GetLastTennisCourt();


    }
}
