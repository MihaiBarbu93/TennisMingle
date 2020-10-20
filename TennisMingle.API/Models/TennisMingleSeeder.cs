/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.Models
{
    public class TennisMingleSeeder
    {
        private readonly AppDbContext _ctx;

        public TennisMingleSeeder(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Cities.Any())
            {
                // Need to create sample data

                var cities = new List<CityDTO>() {

                    new CityDTO {Id = 1,
                     Name = "Bucharest",}
                };

                _ctx.Cities.AddRange(cities);
                _ctx.SaveChanges();
            }

            if(!_ctx.TennisClubs.Any())
            {
                var tennisClubs = new List<TennisClubDTO>() {
                    new TennisClubDTO
                    {
                        Id = 1,
                        Name = "Academia de Tenis Herastrau",
                        Address = "Str. Soseaua Nordului, nr. 7-9, Bucuresti - Sector 1, Bucuresti",
                        PhoneNumber = "0721255444",
                        Prices = new List<int>{ 30, 50 },
                        Schedule = "L-D 7:00 - 24:00",
                        Image = "imagine",
                        Description = "Tenis Parc Herastrau ofera terenuri de tenis cu suprafata de zgura, acoperite pe perioada de iarna, cu structura presostatica si incalzite.Terenurile au suprafata cu zgura de calitate deosebita, sportivii au la dispozitie o terasa unde sa se relaxeze dupa joc, vestiare, wi-fi, si parcare."
                    },
                    new TennisClubDTO
                    {
                        Id = 1,
                        Name = "Academia de Tenis Herastrau 2",
                        Address = "Str. Soseaua Nordului, nr. 7-9, Bucuresti - Sector 1, Bucuresti",
                        PhoneNumber = "0721255444",
                        Prices = new List<int>{ 30, 50 },
                        Schedule = "L-D 7:00 - 24:00",
                        Image = "imagine",
                        Description = "Tenis Parc Herastrau ofera terenuri de tenis cu suprafata de zgura, acoperite pe perioada de iarna, cu structura presostatica si incalzite.Terenurile au suprafata cu zgura de calitate deosebita, sportivii au la dispozitie o terasa unde sa se relaxeze dupa joc, vestiare, wi-fi, si parcare."
                    },
                    new TennisClubDTO
                    {
                        Id = 1,
                        Name = "Academia de Tenis Herastrau 3",
                        Address = "Str. Soseaua Nordului, nr. 7-9, Bucuresti - Sector 1, Bucuresti",
                        PhoneNumber = "0721255444",
                        Prices = new List<int>{ 30, 50 },
                        Schedule = "L-D 7:00 - 24:00",
                        Image = "imagine",
                        Description = "Tenis Parc Herastrau ofera terenuri de tenis cu suprafata de zgura, acoperite pe perioada de iarna, cu structura presostatica si incalzite.Terenurile au suprafata cu zgura de calitate deosebita, sportivii au la dispozitie o terasa unde sa se relaxeze dupa joc, vestiare, wi-fi, si parcare."
                    }
                };

                _ctx.TennisClubs.AddRange(tennisClubs);
                _ctx.SaveChanges();
            }

            if (!ctx.TennisCourts.Any())
            {
                var tennisCourts = new List<TennisCourtDTO>() {
                    new TennisCourtDTO
                    {
                        Id = 1,
                        Name = "Court 1",
                        Surface = Surface.CLAY,
                        Price = 30,
                        IsAvailable = true
                    }
                };
            }
        }
    }
}*/
