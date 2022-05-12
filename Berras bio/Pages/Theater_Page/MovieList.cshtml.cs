#nullable disable
using Berras_bio.Core;
using Berras_bio.Data;
using Berras_bio.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Berras_bio.Pages.Theater_Page
{
    public class MovieListModel : PageModel
    {

        private readonly Berras_bioContext _context;

        public MovieListModel(Berras_bioContext context)
        {
            DataBase data = new();
            data.takenSeats();
            _context = context;
        }

        public IList<MovieModel> MovieModel { get; set; }

        public async Task OnGetAsync()
        {
            MovieModel = await _context.MovieModel.ToListAsync();
        }
    }
}
