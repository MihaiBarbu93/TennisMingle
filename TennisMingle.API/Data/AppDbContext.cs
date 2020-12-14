using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using TennisMingle.API.Entities;

namespace TennisMingle.API.Data
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

            // Higher Priority than the models! Enforces Primary keys for PersonId and TennisCourtId
/*            modelBuilder.Entity<Booking>().HasKey(b => new { b.PersonId, b.TennisCourtId });*/
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<TennisClub> TennisClubs { get; set; }
        public DbSet<TennisCourt> TennisCourts { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Surface> Surfaces { get; set; }
        

    }
}