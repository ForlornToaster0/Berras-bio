using Berras_bio.Data;

namespace Berras_bio.Core
{
    public class DataBase
    {
        public void takenSeats()
        {
            using (var context = new Berras_bioContext())
            {
                Calculation calculation = new();
                var salon = context.Salon.Select(s => s.Seats).FirstOrDefault();
                var movies = context.MovieModel.ToList();
                var titles = movies.Select(m => m.Title).ToList();
                foreach (var title in titles)
                {
                    var maxSeats = movies.Where(m => m.Title == title).FirstOrDefault();
                    var seats = calculation.Calc(title);
                    var takenSeats = salon - seats;
                    var day = maxSeats.Time;

                    if ((DateTime.Now - day).Hours >= 0)
                    {
                        day = day.AddDays(1);
                        maxSeats.Time = day;
                    }
                    maxSeats.Seats = takenSeats;
                    context.SaveChanges();
                }
            }
        }

    }
}
