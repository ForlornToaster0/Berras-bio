#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Berras_bio.Data;
using Berras_bio.Model;

namespace Berras_bio.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly Berras_bio.Data.Berras_bioContext _context;

        public CreateModel(Berras_bio.Data.Berras_bioContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MovieModel MovieModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MovieModel.Add(MovieModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
