#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Berras_bio.Model;

namespace Berras_bio.Data
{
    public class Berras_bioContext : DbContext
    {
        public Berras_bioContext()
        {
        }

        public Berras_bioContext(DbContextOptions<Berras_bioContext> options)
            : base(options)
        {
        }

        public DbSet<Berras_bio.Model.MovieModel> MovieModel { get; set; }

        public DbSet<Berras_bio.Model.Pages_Booking> Booking { get; set; }
        public DbSet<Berras_bio.Model.Salon> Salon { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Berras_bioContext-78a8069c-20a4-492b-a27d-78961d509c3d");
            }
        }

    }
}
