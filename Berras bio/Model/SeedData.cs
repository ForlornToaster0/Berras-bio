using Berras_bio.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Berras_bio.Model;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Berras_bioContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<Berras_bioContext>>()))
        {
            if (context == null || context.MovieModel == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }
            if (context.MovieModel.Any())
            {
                return;   // DB has been seeded
            }
            context.Salon.Add(new Salon { Seats = 50});
            context.Booking.AddRange(
                new Pages_Booking
                {
                    date = DateTime.Now.AddDays(-1),
                    Email = "matteoiamma@onlinecmail.com",
                    FirstName = "Matteo",
                    LastName = "Iamma",
                    Title = "Batman: year one",
                    Tickets = 5

                },
                new Pages_Booking
                {
                    date = DateTime.Now,
                    Email = "mxpro1@cheapnitros.com",
                    FirstName = "Iwo",
                    LastName = "Jama",
                    Title = "Batman: year one",
                    Tickets = 10

                });
            context.MovieModel.AddRange(
                new MovieModel
                {
                    Title = "Batman: year one",
                    Time = DateTime.ParseExact("04:00", "HH:mm", CultureInfo.CurrentCulture),
                    Seats = 50
                },
                      new MovieModel
                      {
                          Title = "The Dark Knight Returns ",
                          Time = DateTime.ParseExact("12:30", "HH:mm", CultureInfo.CurrentCulture),
                          Seats = 50
                      },
                      new MovieModel
                      {
                          Title = "Batman: The long Halloween",
                          Time = DateTime.ParseExact("21:45", "HH:mm", CultureInfo.CurrentCulture),
                          Seats = 50
                      }
                );
            context.SaveChanges();
        }
    }
}
