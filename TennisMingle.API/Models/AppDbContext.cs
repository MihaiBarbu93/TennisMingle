using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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
        public DbSet<AddressDTO> Addresses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Surface> Surfaces { get; set; }
        public DbSet<Facility> Facilities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
