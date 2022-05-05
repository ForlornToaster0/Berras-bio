using Berras_bio.Data;

namespace Berras_bio.Core
{
    public class Calculation
    {
        public float Calc(string title)
        {
            using (var context = new Berras_bioContext())
            {
                float numNew = 0;
                var movieTime = context.MovieModel.Where(n => n.Title == title).Select(movie => movie.Time).FirstOrDefault();

                var takenSeats = context.Booking.Where(b => b.date > movieTime.AddDays(-1) && b.date < movieTime &&
                b.Title == title).Select(b => b.Tickets).ToArray();

                foreach (var takenSeat in takenSeats)
                {
                    numNew = numNew + float.Parse(takenSeat.ToString());
                }

                return numNew;

            }

        }

    }

}
