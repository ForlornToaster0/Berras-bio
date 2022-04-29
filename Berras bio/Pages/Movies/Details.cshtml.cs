﻿#nullable disable
using Berras_bio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Berras_bio.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly Berras_bio.Data.Berras_bioContext _context;

        public DetailsModel(Berras_bio.Data.Berras_bioContext context)
        {
            _context = context;
        }

        public MovieModel MovieModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieModel = await _context.MovieModel.FirstOrDefaultAsync(m => m.ID == id);

            if (MovieModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}