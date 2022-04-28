#nullable disable
using Berras_bio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Berras_bio.Pages.Booking;

public class BookingModel : PageModel
{
    private readonly Berras_bio.Data.Berras_bioContext _context;

    public BookingModel(Berras_bio.Data.Berras_bioContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Pages_Booking Pages_Booking { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Booking.Add(Pages_Booking);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
