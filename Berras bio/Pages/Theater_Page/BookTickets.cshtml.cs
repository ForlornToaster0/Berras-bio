#nullable disable
using Berras_bio.Core;
using Berras_bio.Data;
using Berras_bio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Berras_bio.Pages.Theater_Page;

public class BookTicketsModel : PageModel
{
    private readonly Berras_bioContext _context;
    public List<SelectListItem> movieOptions { get; set; }
    
    [BindProperty]
    public Pages_Booking Pages_Booking { get; set; }

    public BookTicketsModel(Berras_bioContext context)
    {
        _context = context;
    }

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

    public async Task<IActionResult> OnPostAsync()
    {
        DBCheck dBCheck = new();
        bool check = dBCheck.NotNegative(Pages_Booking.Title, Pages_Booking.Tickets);
        if (ModelState.IsValid)
        {
            if (check == true)
            {
                Pages_Booking.date = DateTime.Now;
                _context.Booking.Add(Pages_Booking);
                await _context.SaveChangesAsync();
                return RedirectToPage("BookingSuccess");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "There is not enough tickes available for this movie");
                OnGet();
                return Page(); 
            }
        }
        else
        {
            return Page();
        }

    }
}