using System;
using api_sepomex.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public class DataGenerator
{

    async public static void Initialize(IServiceProvider serviceProvider)
    {

        using (var context = new IntranetContext(
            serviceProvider.GetRequiredService<DbContextOptions<IntranetContext>>()))
        {

            // Look for any board games.
            if (await context.Country.AnyAsync())
            {
                return;   // Data was already seeded
            }

            context.Country.AddRange(
                new Country
                {
                    CountryID = 1,
                    UserID =1,
                    Name = "Mexico",
                    CurrencyCode = "MXN",
                    Currency = "PESOS",
                    Code = "MX",
                    LastChange = DateTime.Now,
                    Active = true
                });

            // Look for any board games.
            if (await context.User.AnyAsync())
            {
                return;   // Data was already seeded
            }

            context.User.AddRange(new User
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                Username = "Admin",
                Password = "Admin",
                IsAuth = true,
                Token =  ""
            });

            context.SaveChanges();
        }
    }
}