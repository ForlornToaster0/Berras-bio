#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Berras_bio.Data;
using Berras_bio.Model;

namespace Berras_bio.Pages.Booking
{
    public class IndexModel : PageModel
    {
        private readonly Berras_bio.Data.Berras_bioContext _context;

        public IndexModel(Berras_bio.Data.Berras_bioContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; }

        public async Task OnGetAsync()
        {
            Booking = await _context.Booking.ToListAsync();
        }
    }
}
