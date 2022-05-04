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

                    var maxSeats = movies.Where(m => m.Title == title).Select(m => m.Seats).FirstOrDefault();
                    var seats = calculation.Calc(title);
                    var takenSeats = salon - seats;
                    maxSeats = takenSeats;
                    context.SaveChanges();
                }
            }
        }

    }
}
