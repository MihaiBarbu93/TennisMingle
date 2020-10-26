using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace TennisMingle.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                                                    .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.Entity<Booking>().HasKey(b => new { b.PersonId, b.TennisCourtId });
           

        }


        public DbSet<City> Cities { get; set; }
        public DbSet<TennisClub> TennisClubs { get; set; }
        public DbSet<TennisCourt> TennisCourts { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<TennisClubAddress> Addresses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Surface> Surfaces { get; set; }
        public DbSet<Facility> Facilities { get; set; }


        

    }
}