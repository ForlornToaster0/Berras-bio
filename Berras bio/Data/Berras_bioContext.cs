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

        public Berras_bioContext (DbContextOptions<Berras_bioContext> options)
            : base(options)
        {
        }

        public DbSet<Berras_bio.Model.MovieModel> MovieModel { get; set; }

        public DbSet<Berras_bio.Model.Booking> Booking { get; set; }

    }
}
