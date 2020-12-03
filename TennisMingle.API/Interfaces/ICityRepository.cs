using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Entities;

namespace TennisMingle.API.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCities();
        Task<City> GetCity(int id);
        Task<City> GetCity(string name);

        void AddCity(City city);

        Task<bool> SaveAllAsync();
        Task<bool> CityExists(string name);
    }
}
