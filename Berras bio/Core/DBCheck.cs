using Berras_bio.Data;

namespace Berras_bio.Core;

public class DBCheck
{
    public bool NotNegative(string title, int tickets)
    {
        bool check = true;
        using (var context = new Berras_bioContext())
        {
            var seats = context.MovieModel
                .Where(m => m.Title == title)
                .Select(m => m.Seats)
                .FirstOrDefault();

            if (seats <= 0 || seats - tickets <= 0)
            {
                check = false;
            }
            return check;
        }
    }
}
