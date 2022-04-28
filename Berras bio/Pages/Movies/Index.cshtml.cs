#nullable disable
using Berras_bio.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Berras_bio.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Berras_bio.Data.Berras_bioContext _context;

        public IndexModel(Berras_bio.Data.Berras_bioContext context)
        {
            _context = context;
        }

        public IList<MovieModel> MovieModel { get; set; }

        public async Task OnGetAsync()
        {
            MovieModel = await _context.MovieModel.ToListAsync();
        }
    }
}
