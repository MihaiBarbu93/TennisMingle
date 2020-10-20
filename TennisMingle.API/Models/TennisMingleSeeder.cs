using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Enums;

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

            if (_ctx.Cities.Any() && _ctx.TennisClubs.Any() && _ctx.Addresses.Any() && _ctx.Persons.Any() && 
                _ctx.Bookings.Any() && _ctx.Facilities.Any() && _ctx.Surfaces.Any() && _ctx.TennisCourts.Any())
            {
                return;
            }
            // Need to create sample data

            var cities = new List<CityDTO>() {

                new CityDTO {Id = 1,
                    Name = "Bucharest",}
            };

            _ctx.Cities.AddRange(cities);
            _ctx.SaveChanges();

            var addresses = new List<AddressDTO>() {

                new AddressDTO 
                {   
                    Id = 1,
                    Address = "Str. Soseaua Nordului, nr. 7-9, Bucuresti - Sector 1, Bucuresti",
                    CityId =1
                },
                new AddressDTO
                {
                    Id = 2,
                    Address = "Str. Soseaua Sudului, nr. 4-6, Bucuresti - Sector 1, Bucuresti",
                    CityId = 1
                },
                new AddressDTO
                {
                    Id = 3,
                    Address = "Str. Soseaua Sudului, nr. 25, Bucuresti - Sector 2, Bucuresti",
                    CityId = 1
                }

            };

            _ctx.Addresses.AddRange(addresses);
            _ctx.SaveChanges();

            var tennisClubs = new List<TennisClubDTO>() {
                new TennisClubDTO
                {
                    Id = 1,
                    Name = "Academia de Tenis Herastrau",
                    AddressId = 1 ,
                    PhoneNumber = "0721255444",
                    Schedule = "L-D 7:00 - 24:00",
                    Image = "imagine",
                    Description = "Tenis Parc Herastrau ofera terenuri de tenis cu suprafata de zgura, acoperite pe perioada de iarna, cu structura presostatica si incalzite.Terenurile au suprafata cu zgura de calitate deosebita, sportivii au la dispozitie o terasa unde sa se relaxeze dupa joc, vestiare, wi-fi, si parcare."
                },
                new TennisClubDTO
                {
                    Id = 2,
                    Name = "Academia de Tenis Herastrau 2",
                    AddressId = 2,
                    PhoneNumber = "0721255444",
                    Schedule = "L-D 7:00 - 24:00",
                    Image = "imagine",
                    Description = "Tenis Parc Herastrau ofera terenuri de tenis cu suprafata de zgura, acoperite pe perioada de iarna, cu structura presostatica si incalzite.Terenurile au suprafata cu zgura de calitate deosebita, sportivii au la dispozitie o terasa unde sa se relaxeze dupa joc, vestiare, wi-fi, si parcare."
                },
                new TennisClubDTO
                {
                    Id = 3,
                    Name = "Academia de Tenis Herastrau 3",
                    AddressId = 3,
                    PhoneNumber = "0721255444",
                    Schedule = "L-D 7:00 - 24:00",
                    Image = "imagine",
                    Description = "Tenis Parc Herastrau ofera terenuri de tenis cu suprafata de zgura, acoperite pe perioada de iarna, cu structura presostatica si incalzite.Terenurile au suprafata cu zgura de calitate deosebita, sportivii au la dispozitie o terasa unde sa se relaxeze dupa joc, vestiare, wi-fi, si parcare."
                }
            };

            _ctx.TennisClubs.AddRange(tennisClubs);
            _ctx.SaveChanges();

            var surfaces = new List<Surface>() {

                new Surface 
                {
                    Id = 1,
                    SurfaceType = Surfaces.GRASS
                },
                new Surface
                {
                    Id = 2,
                    SurfaceType = Surfaces.CLAY
                },
                new Surface
                {
                    Id = 3,
                    SurfaceType = Surfaces.ACRYLIC
                },
                new Surface
                {
                    Id = 3,
                    SurfaceType = Surfaces.CARPET
                }
            };

            _ctx.Surfaces.AddRange(surfaces);
            _ctx.SaveChanges();

            var facilities = new List<Facility>() {

                new Facility
                {
                    Id = 1,
                    FacilityType = Facilities.BAR
                },
                new Facility
                {
                    Id = 2,
                    FacilityType = Facilities.DRESSROOM
                },
                new Facility
                {
                    Id = 3,
                    FacilityType = Facilities.NOCTURNE
                },
                new Facility
                {
                    Id = 4,
                    FacilityType = Facilities.PARKING,
                    
                }
            };

            _ctx.Facilities.AddRange(facilities);
            _ctx.SaveChanges();



            var tennisCourts = new List<TennisCourtDTO>() {
                new TennisCourtDTO
                {
                    Id = 1,
                    Name = "Court 1",
                    SurfaceId = 2,
                    Price = 30,
                    IsAvailable = true,
                    TennisClubId = 1
                },
                new TennisCourtDTO
                {
                    Id = 2,
                    Name = "Court 2",
                    SurfaceId = 1,
                    Price = 40,
                    IsAvailable = true,
                    TennisClubId = 1
                },
                new TennisCourtDTO
                {
                    Id = 3,
                    Name = "Court 1",
                    SurfaceId = 2,
                    Price = 30,
                    IsAvailable = true,
                    TennisClubId = 2
                },
                new TennisCourtDTO
                {
                    Id = 4,
                    Name = "Court 1",
                    SurfaceId = 2,
                    Price = 30,
                    IsAvailable = true,
                    TennisClubId = 3
                }

            };
            _ctx.TennisCourts.AddRange(tennisCourts);
            _ctx.SaveChanges();

            var persons = new List<PersonDTO>() {
                new PersonDTO
                {
                    Id = 1,
                    FirstName = "Vasilica",
                    LastName = "Dancilica",
                    Bio = "yyyy",
                    Photo = "sdsdss",
                    Type = PersonType.ADMINISTRATOR,
                    TennisClubId = 1
                },
                new PersonDTO
                {
                    Id = 2,
                    FirstName = "Ion",
                    LastName = "Ion",
                    Bio = "fsfd",
                    TennisClubId = 1,
                    Photo = "fdf",
                    Type = PersonType.COACH

                },
                new PersonDTO
                {
                    Id = 3,
                    FirstName = "Marius",
                    LastName = "SiMaiCum",
                    Bio = "gfhfh",
                    TennisClubId = 2,
                    Photo = "kkkkk",
                    Type = PersonType.COACH

                },
                new PersonDTO
                {
                    Id = 4,
                    FirstName = "Vasilica",
                    LastName = "Dancilica",
                    Bio = "yyyy",
                    Photo = "sdsdss",
                    Type = PersonType.USER
                },
            };
            _ctx.Persons.AddRange(persons);
            _ctx.SaveChanges();
        }
    }
}
