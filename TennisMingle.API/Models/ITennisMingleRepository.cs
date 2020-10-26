using System.Collections.Generic;

namespace TennisMingle.API.Models
{
    public interface ITennisMingleRepository
    {
        IEnumerable<City> GetAllCities();
        IEnumerable<City> GetCityById(int id);
    }
}