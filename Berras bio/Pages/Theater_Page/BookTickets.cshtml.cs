#nullable disable
using Berras_bio.Data;
using Berras_bio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Berras_bio.Pages.Theater_Page;

public class BookTicketsModel : PageModel
{
    private readonly Berras_bioContext _context;

    
    [BindProperty]
    public Pages_Booking Pages_Booking { get; set; }

    public BookTicketsModel(Berras_bioContext context)
    {
        _context = context;
    }
    public List<SelectListItem> movieOptions { get; set; }

    public IActionResult OnGet()
    {
        movieOptions = _context.MovieModel
            .Select(a =>
               new SelectListItem
               {
                   Value = a.Title.ToString(),
                   Text = a.Title
               }).ToList();

        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            return RedirectToPage("BookingSuccess");
        }
        else
        {
            return Page();
        }

        Pages_Booking.date = DateTime.Now;
        _context.Booking.Add(Pages_Booking);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Index");
    }
}
