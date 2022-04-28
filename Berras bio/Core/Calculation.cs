using Berras_bio.Data;

namespace Berras_bio.Core
{
    public class Calculation
    {
        public void Calc()
        {
            using (var context = new Berras_bioContext())
            {
                var takenSeats = context.Booking.Where(b => b.DateTime.Date == DateTime.Now.Date).Select(b=>b.Tickets).ToArray();
                foreach(var takenSeat in takenSeats)
                {
                    float numNew =+ takenSeat;
                }


            }
        }
    }
}
