#nullable disable
using Microsoft.EntityFrameworkCore;

namespace Berras_bio.Data
{
    public class Berras_bioContext : DbContext
    {
        public Berras_bioContext(DbContextOptions<Berras_bioContext> options)
            : base(options)
        {
        }

        public DbSet<Berras_bio.Model.MovieModel> MovieModel { get; set; }

        public DbSet<Berras_bio.Model.Pages_Booking> Booking { get; set; }
    }
}
