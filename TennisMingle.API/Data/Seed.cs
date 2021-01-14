using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using TennisMingle.API.Entities;

namespace TennisMingle.API.Data
{
    public class Seed
    {
        public static async Task SeedCities(AppDbContext context, UserManager<AppUser> userManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var cities = JsonSerializer.Deserialize<List<City>>(userData);

            if (cities == null) return;
            foreach (var city in cities)
            {
                await context.Cities.AddAsync(city);
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