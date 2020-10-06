using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Models;

namespace TennisMingle.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current {get;} = new CitiesDataStore();
        public List<CityDTO> Cities { get; set; } = new List<CityDTO>();

        public CitiesDataStore()
        {
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
                             Surface = "clay",
                             Facilities = new List<string> {"parking", "dressroom"},
                             Address = "Str. Soseaua Nordului, nr. 7-9, Bucuresti - Sector 1, Bucuresti",
                             PhoneNumber = "0721255444",
                             Prices = "50lei/h",
                             Schedule = "L-D 7:00 - 24:00",
                             Image = "imagine",
                             Description = "Tenis Parc Herastrau ofera terenuri de tenis cu suprafata de zgura, acoperite pe perioada de iarna, cu structura presostatica si incalzite.Terenurile au suprafata cu zgura de calitate deosebita, sportivii au la dispozitie o terasa unde sa se relaxeze dupa joc, vestiare, wi-fi, si parcare." },
                          new TennisClubDTO() {
                            Id = 2,
                             Name = "Academia de Tenis Herastrau 2",
                             Surface = "clay",
                             Facilities = new List<string> {"parking", "dressroom"},
                             Address = "Str. Soseaua Nordului, nr. 7-9, Bucuresti - Sector 1, Bucuresti",
                             PhoneNumber = "0721255444",
                             Prices = "50lei/h",
                             Schedule = "L-D 7:00 - 24:00",
                             Image = "imagine",
                             Description = "Tenis Parc Herastrau ofera terenuri de tenis cu suprafata de zgura, acoperite pe perioada de iarna, cu structura presostatica si incalzite.Terenurile au suprafata cu zgura de calitate deosebita, sportivii au la dispozitie o terasa unde sa se relaxeze dupa joc, vestiare, wi-fi, si parcare." },
                          new TennisClubDTO() {
                            Id = 3,
                             Name = "Academia de Tenis Herastrau 3",
                             Surface = "clay",
                             Facilities = new List<string> {"parking", "dressroom"},
                             Address = "Str. Soseaua Nordului, nr. 7-9, Bucuresti - Sector 1, Bucuresti",
                             PhoneNumber = "0721255444",
                             Prices = "50lei/h",
                             Schedule = "L-D 7:00 - 24:00",
                             Image = "imagine",
                             Description = "Tenis Parc Herastrau ofera terenuri de tenis cu suprafata de zgura, acoperite pe perioada de iarna, cu structura presostatica si incalzite.Terenurile au suprafata cu zgura de calitate deosebita, sportivii au la dispozitie o terasa unde sa se relaxeze dupa joc, vestiare, wi-fi, si parcare." },
                     }
                }
            };
        }
    }
}
