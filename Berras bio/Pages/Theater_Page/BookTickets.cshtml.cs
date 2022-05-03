#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Berras_bio.Model;

namespace Berras_bio.Pages.Theater_Page;

public class BookTicketsModel : PageModel
{
    private readonly Data.Berras_bioContext _context;

    public BookTicketsModel(Data.Berras_bioContext context)
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
