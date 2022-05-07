#nullable disable
using Microsoft.EntityFrameworkCore;

namespace Berras_bio.Data;

public class Berras_bioContext : DbContext
{
    public Berras_bioContext()
    {
    }

    public Berras_bioContext(DbContextOptions<Berras_bioContext> options)
        : base(options)
    {
    }

    public DbSet<Model.MovieModel> MovieModel { get; set; }

    public DbSet<Model.Pages_Booking> Booking { get; set; }
    public DbSet<Model.Salon> Salon { get; set; }
    public object Pages_Booking { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Berras_bioContext-78a8069c-20a4-492b-a27d-78961d509c3d");
        }
    }

}
