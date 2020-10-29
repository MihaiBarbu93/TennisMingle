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

            if (_ctx.Cities.Any() && _ctx.TennisClubs.Any() && _ctx.Addresses.Any() && _ctx.Persons.Any() && _ctx.Facilities.Any() && _ctx.Surfaces.Any() && _ctx.TennisCourts.Any())
            {
                return;
            }
            // Need to create sample data


            if (!_ctx.Cities.Any()) {
                var cities = new List<City>() {

                new City {
                    Name = "Bucharest"},
                new City
                {
                    Name = "Brasov"},
                new City
                {
                    Name = "Cluj"},
                new City
                {
                    Name = "Timisoara"},
                new City
                {
                    Name = "Iasi"}
            };

                _ctx.Cities.AddRange(cities);
                _ctx.SaveChanges();
            }


            if (!_ctx.Addresses.Any())
            {
                var addresses = new List<TennisClubAddress>() {

                new TennisClubAddress
                {
                    Address = "Str. Soseaua Nordului, nr. 7-9, Bucuresti - Sector 1, Bucuresti",
                    CityId =1
                },
                new TennisClubAddress
                {
                    Address = "Strada Gheorghe Petrașcu 51, București",
                    CityId = 1
                },
                new TennisClubAddress
                {
                    Address = "Strada Oltețului 30, București",
                    CityId = 1
                }

            };

                _ctx.Addresses.AddRange(addresses);
                _ctx.SaveChanges();
            }

            if (!_ctx.TennisClubs.Any())
            {
                var tennisClubs = new List<TennisClub>() {
                new TennisClub
                {
                    Name = "Academia de Tenis Herastrau",
                    AddressId = 1 ,
                    PhoneNumber = "0721255444",
                    Schedule = "L-D 7:00 - 24:00",
                    Image = "tc4.jpeg",
                    Description = "Tenis Parc Herastrau ofera terenuri de tenis cu suprafata de zgura, acoperite pe perioada de iarna, cu structura presostatica si incalzite.Terenurile au suprafata cu zgura de calitate deosebita, sportivii au la dispozitie o terasa unde sa se relaxeze dupa joc, vestiare, wi-fi, si parcare."
                },
                new TennisClub
                {
                    Name = "Club Sportiv Voinicelu",
                    AddressId = 2,
                    PhoneNumber = "0733991722",
                    Schedule = "L-D 7:00 - 24:00",
                    Image = "tc2.jpeg",
                    Description = "La Clubul Voinicelu se poate juca atat tenis, pe cele 7 terenuri de zgura, accesibile tot anul, cat si fotbal, pe cele 2 terenuri de minifotbal.Clubul se afla in Piata Muncii, pe Strada Gheorghe Petrascu, la numarul 43-45, suficient de aproape de statia de metrou, dar si destul de departe de traficul zgomotos al bulevardului,inconjurat de copaci umbrosi, intr-un cartier linistit de blocuri, iar atmosfera creata este potrivita atat pentru antrenamentele si meciurile dinamice, cat si pentru relaxare.Printre alte facilitati ale clubului se numara parcarea in limita disponibilitati cu supraveghere video, optiuni de inchiriere si/sau racordari de rachete de tenis, vestiare femei si barbati."
                },
                new TennisClub
                {
                    Name = "Tenis Club Galaxy",
                    AddressId = 3,
                    PhoneNumber = "0747425299",
                    Schedule = "L-D 7:00 - 24:00",
                    Image = "tc5.jpeg",
                    Description = "Formarea tinerilor sportivi pentru toate aspectele vietii, folosind ca intrumente tenisul si educatia sportiva este o preocupare permanenta. Toti jucatorii vor beneficia de o atentie deosebita din partea noastra pentru ca performantele lor sa fie maxime in atingerea obiectivelor propuse. Copiii cu varste cuprinse intre 5-10 ani, pot beneficia de programe de initiere si minitenis, cei mai mari de programe pentru avansati si performanta.Adultii pot inchiria terenuri sau beneficia de lectii private de initiere si/sau perfectionare sub indrumarea  antrenorilor nostri.Practicarea tenisului in sezonul rece se face in conditii foarte bune, deoarece 6 terenuri sunt acoperite cu baloane protectoare, mentinand in interior presiunea si temperatura optima jocului de tenis. Pe perioada sezonului in aer liber terenurile noastre, dotate cu nocturna, permit practicarea tenisului pana la ora 24. Pregatirea fizica si recuperarea, pot fi efectuate in sala de fitness, aerobic si sauna din cadrul clubului."
                }
            };

                _ctx.TennisClubs.AddRange(tennisClubs);
                _ctx.SaveChanges();
            }

            if (!_ctx.Surfaces.Any())
            {
                var surfaces = new List<Surface>() {

                new Surface
                {
                    SurfaceType = Surfaces.GRASS
                },
                new Surface
                {
                    SurfaceType = Surfaces.CLAY
                },
                new Surface
                {
                    SurfaceType = Surfaces.ACRYLIC
                },
                new Surface
                {
                    SurfaceType = Surfaces.CARPET
                }
            };

                _ctx.Surfaces.AddRange(surfaces);
                _ctx.SaveChanges();
            }

            if (!_ctx.Facilities.Any())
            {
                var facilities = new List<Facility>() {

                new Facility
                {
                    FacilityType = Facilities.BAR,
                    TennisClubId = 2
                },
                new Facility
                {
                    FacilityType = Facilities.DRESSROOM,
                    TennisClubId = 2
                },
                new Facility
                {
                    FacilityType = Facilities.NOCTURNE,
                    TennisClubId = 1
                },
                new Facility
                {
                    FacilityType = Facilities.PARKING,
                    TennisClubId = 1
                }
            };

                _ctx.Facilities.AddRange(facilities);
                _ctx.SaveChanges();
            }


            if (!_ctx.TennisCourts.Any())
            {
                var tennisCourts = new List<TennisCourt>() {
                new TennisCourt
                {
                    Name = "Court 1",
                    SurfaceId = 2,
                    Price = 30,
                    IsAvailable = true,
                    TennisClubId = 1
                },
                new TennisCourt
                {
                    Name = "Court 2",
                    SurfaceId = 1,
                    Price = 40,
                    IsAvailable = true,
                    TennisClubId = 1
                },
                new TennisCourt
                {
                    Name = "Court 1",
                    SurfaceId = 3,
                    Price = 30,
                    IsAvailable = true,
                    TennisClubId = 2
                },
                new TennisCourt
                {
                    Name = "Court 1",
                    SurfaceId = 4,
                    Price = 30,
                    IsAvailable = true,
                    TennisClubId = 3
                }

            };
                _ctx.TennisCourts.AddRange(tennisCourts);
                _ctx.SaveChanges();
            }

            if (!_ctx.Persons.Any())
            {
                var persons = new List<Person>() {
                new Person
                {
                    FirstName = "Nick",
                    LastName = "Bollettieri",
                    Bio = "Nicholas James Bollettieri (born July 31, 1931) is an American tennis coach. He pioneered the concept of a tennis boarding school, and helped develop many leading tennis players during the past decades, including Andre Agassi, Jim Courier, Monica Seles, and Mary Pierce.",
                    Photo = "sdsdss",
                    Type = PersonType.ADMINISTRATOR,
                    TennisClubId = 1
                },
                new Person
                {
                    FirstName = "Patrick",
                    LastName = "Mouratoglou",
                    Bio = "He founded the Mouratoglou Tennis Academy in 1996 near Paris (later relocated to the outskirts of Nice), and has coached many up-and-coming players, including Marcos Baghdatis (whom he coached to the final of the 2006 Australian Open), Julia Vakulenko, Anastasia Pavlyuchenkova, Aravane Rezaï, Jérémy Chardy, Laura Robson, Yanina Wickmayer and Grigor Dimitrov.",
                    TennisClubId = 1,
                    Photo = "fdf",
                    Type = PersonType.COACH

                },
                new Person
                {
                    FirstName = "Darren",
                    LastName = "Cahill",
                    Bio = "Darren Cahill (born 2 October 1965) is a tennis coach and former professional tennis player from Australia. In addition, Cahill is a tennis analyst for the Grand Slam events on the US sports network ESPN and a coach with the Adidas Player Development Program and at ProTennisCoach.com",
                    TennisClubId = 2,
                    Photo = "kkkkk",
                    Type = PersonType.COACH

                },
                new Person
                {
                    FirstName = "Horia",
                    LastName = "Tecau",
                    Bio = "Horia Tecău, born January 19, is a Romanian tennis player currently ranked World No. 11 in doubles.",
                    Photo = "sdsdss",
                    Type = PersonType.USER
                },
            };
                _ctx.Persons.AddRange(persons);
                _ctx.SaveChanges();
            }
        }           
    }
}
