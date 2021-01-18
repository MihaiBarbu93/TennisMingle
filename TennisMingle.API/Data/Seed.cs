using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using TennisMingle.API.Entities;
using TennisMingle.API.Extensions;

namespace TennisMingle.API.Data
{
    public class Seed
    {
        public static async Task SeedCities(AppDbContext context, UserManager<AppUser> userManager, 
                            RoleManager<AppRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            /*var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");*/
            var cities = JsonExtensions.LoadFromFileWithGeoJson<List<City>>("Data/UserSeedData.json");

            if (cities == null) return;
            foreach (var city in cities)
            {
                await context.Cities.AddAsync(city);
            }

            var roles = new List<AppRole>
            {
                new AppRole{Name = "Administrator"},
                new AppRole{Name = "Player"},
                new AppRole{Name = "Coach"}
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            await context.SaveChangesAsync();

            await UsersPasswordEncryption(context);
        }

        private static async Task UsersPasswordEncryption(AppDbContext context)
        {
            foreach (var user in context.Users)
            {

                user.UserName = user.UserName.ToLower();

            }

            await context.SaveChangesAsync();
        }
    }
}