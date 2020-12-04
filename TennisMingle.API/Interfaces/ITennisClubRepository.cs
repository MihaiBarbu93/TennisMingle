using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Entities;

namespace TennisMingle.API.Interfaces
{
    public interface ITennisClubRepository
    {
        Task<IEnumerable<TennisClub>> GetTennisClubsAsync(int cityId);
        Task<IEnumerable<TennisClub>> GetTennisClubsWithCourtsAvailableAsync(int cityId);
        Task<TennisClub> GetTenisClubByIdAsync(int tennisClubId);
        Task<TennisClub> CreateTennisClubAsync(int cityId, TennisClub tennisClub);
        void UpdateTennisClubAsync(int cityId, int tennisClubId, TennisClub tennisClub);
        void DeleteTennisClub(int cityId, int tennisClubId);
        Task<bool> SaveAllAsync();
        int GetIdForCreatedTennisClub();

    }
}
