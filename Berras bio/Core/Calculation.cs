using Berras_bio.Data;

namespace Berras_bio.Core
{
    public class Calculation
    {
        public float Calc(string title)
        {
            using (var context = new Berras_bioContext())
            {
                float numNew =0;
                var takenSeats = context.Booking.Where(b => b.DateTime.Date == DateTime.Now.Date&&b.Title==title).Select(b=>b.Tickets).ToArray();
                foreach(var takenSeat in takenSeats)
                {
                     numNew =+ float.Parse(takenSeat.ToString());
                }
                return numNew;

            }
        }
    }
}
