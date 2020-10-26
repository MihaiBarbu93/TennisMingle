using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.Models
{
    public class TennisMingleRepository : ITennisMingleRepository
    {
        private AppDbContext _ctx;

        public TennisMingleRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<City> GetAllCities()
        {
            return _ctx.Cities
                       .OrderBy(c => c.Name)
                       .ToList();
        }

        public IEnumerable<City> GetCityById(int id)
        {
            return _ctx.Cities
                       .Where(c => c.Id == id)
                       .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
