using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CityDTO> Cities { get; set; }
        public DbSet<TennisClubDTO> TennisClubs { get; set; }
        public DbSet<TennisCourtDTO> TennisCourts { get; set; }
        public DbSet<PersonDTO> Person { get; set; }


    }
