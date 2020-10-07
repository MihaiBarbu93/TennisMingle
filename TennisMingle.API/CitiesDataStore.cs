using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Enums;
using TennisMingle.API.Models;

namespace TennisMingle.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current {get;} = new CitiesDataStore();
        public List<CityDTO> Cities { get; set; } = new List<CityDTO>();
        public List<CoachDTO> Coaches { get; set; } = new List<CoachDTO>();

        public CitiesDataStore()


        {

            Coaches = new List<CoachDTO>()
            {
                new CoachDTO()
                {
                    Id = 1,
                    Name = "Darren Cahill",
                    Bio = "Simona Halep's coach",
                    Photo = "the photo",
                },
                new CoachDTO()
                {
                    Id = 2,
                    Name = "Patrick Mouratoglu",
                    Bio = "A turkish coach",
                    Photo = "the photo",
                },
                new CoachDTO()
                {
                    Id = 3,
                    Name = "Wim Fissette",
                    Bio = "A belgian poker-faced coach",
                    Photo = "the photo",
                },
                new CoachDTO()
                {
                    Id = 4,
                    Name = "Sergio Giorgi",
                    Bio = "A mad italian coach",
                    Photo = "the photo",
                },
                new CoachDTO()
                {
                    Id = 5,
                    Name = "Judy Murray",
                    Bio = "Andy Murray's mom",
                    Photo = "the photo",
                },
                new CoachDTO()
                {
                    Id = 6,
                    Name = "Kamau Murray",
                    Bio = "An afro-american coach",
                    Photo = "the photo",
                }
            };

            Cities = new List<CityDTO>()
            {
                new CityDTO()
                {
                     Id = 1,
                     Name = "Bucharest",
                     TennisClubs = new List<TennisClubDTO>()
                     {
                         new TennisClubDTO() {
                             Id = 1,
                             Name = "Academia de Tenis Herastrau",
                             Surfaces = new List<Surface>{ Surface.CLAY },
                             Facilities = new List<Facilities> {Facilities.PARKING, Facilities.DRESSROOM},
                             Coaches = new List<CoachDTO>() {
                                Coaches.FirstOrDefault(co => co.Id == 1),
                                Coaches.FirstOrDefault(co => co.Id == 3),
                                Coaches.FirstOrDefault(co => co.Id == 5),
                             },
                             Address = "Str. Soseaua Nordului, nr. 7-9, Bucuresti - Sector 1, Bucuresti",
                             PhoneNumber = "0721255444",
                             Prices = new List<int>{ 30, 50 },
                             Schedule = "L-D 7:00 - 24:00",
                             Image = "imagine",
                             Description = "Tenis Parc Herastrau ofera terenuri de tenis cu suprafata de zgura, acoperite pe perioada de iarna, cu structura presostatica si incalzite.Terenurile au suprafata cu zgura de calitate deosebita, sportivii au la dispozitie o terasa unde sa se relaxeze dupa joc, vestiare, wi-fi, si parcare." },
                          new TennisClubDTO() {
                            Id = 2,
                             Name = "Academia de Tenis Herastrau 2",
                             Surfaces = new List<Surface>{ Surface.CLAY, Surface.GRASS },
                             Facilities = new List<Facilities> {Facilities.PARKING, Facilities.DRESSROOM, Facilities.NOCTURNE},
                             Coaches =  Coaches.Where(co => new int[]{1,2,6}.Contains(co.Id)).ToList(),
                             Address = "Str. Soseaua Nordului, nr. 7-9, Bucuresti - Sector 1, Bucuresti",
                             PhoneNumber = "0721255444",
                             Prices = new List<int>{ 30, 50, 80 },
                             Schedule = "L-D 7:00 - 24:00",
                             Image = "imagine",
                             Description = "Tenis Parc Herastrau ofera terenuri de tenis cu suprafata de zgura, acoperite pe perioada de iarna, cu structura presostatica si incalzite.Terenurile au suprafata cu zgura de calitate deosebita, sportivii au la dispozitie o terasa unde sa se relaxeze dupa joc, vestiare, wi-fi, si parcare." },
                          new TennisClubDTO() {
                            Id = 3,
                             Name = "Academia de Tenis Herastrau 3",
                             Surfaces = new List<Surface>{ Surface.CLAY, Surface.GRASS, Surface.ACRYLIC },
                             Facilities = new List<Facilities> {Facilities.PARKING, Facilities.DRESSROOM, Facilities.NOCTURNE},
                             Coaches = new List<CoachDTO>() {
                                Coaches.FirstOrDefault(co => co.Id == 3),
                                Coaches.FirstOrDefault(co => co.Id == 4),
                                Coaches.FirstOrDefault(co => co.Id == 6),
                             },
                             Address = "Str. Soseaua Nordului, nr. 7-9, Bucuresti - Sector 1, Bucuresti",
                             PhoneNumber = "0721255444",
                             Prices = new List<int>{ 50, 80 },
                             Schedule = "L-D 7:00 - 24:00",
                             Image = "imagine",
                             Description = "Tenis Parc Herastrau ofera terenuri de tenis cu suprafata de zgura, acoperite pe perioada de iarna, cu structura presostatica si incalzite.Terenurile au suprafata cu zgura de calitate deosebita, sportivii au la dispozitie o terasa unde sa se relaxeze dupa joc, vestiare, wi-fi, si parcare." },
                          new TennisClubDTO() {
                            Id = 4,
                             Name = "Academia de Tenis Herastrau 4",
                             Surfaces = new List<Surface>{ Surface.CLAY, Surface.ASPHALT },
                             Facilities = new List<Facilities> {Facilities.PARKING, Facilities.DRESSROOM, Facilities.SHOWERS},
                             Coaches = new List<CoachDTO>() {
                                Coaches.FirstOrDefault(co => co.Id == 2),
                                Coaches.FirstOrDefault(co => co.Id == 4),
                                Coaches.FirstOrDefault(co => co.Id == 5),
                             },
                             Address = "Str. Soseaua Nordului, nr. 7-9, Bucuresti - Sector 1, Bucuresti",
                             PhoneNumber = "0721255444",
                             Prices = new List<int>{ 50, 80 },
                             Schedule = "L-D 7:00 - 24:00",
                             Image = "imagine",
                             Description = "Tenis Parc Herastrau ofera terenuri de tenis cu suprafata de zgura, acoperite pe perioada de iarna, cu structura presostatica si incalzite.Terenurile au suprafata cu zgura de calitate deosebita, sportivii au la dispozitie o terasa unde sa se relaxeze dupa joc, vestiare, wi-fi, si parcare." },
                     }
                }
            };
        }
    }
}
