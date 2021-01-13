using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TennisMingle.API.Entities;

namespace TennisMingle.API.Data
{
    public class Seed
    {
        public static async Task SeedCities(AppDbContext context)
        {
            if (await context.Cities.AnyAsync()) return;

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