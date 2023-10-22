using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ghiriti_Edmond_Lab2.Data;
using Ghiriti_Edmond_Lab2.Models;

namespace Ghiriti_Edmond_Lab2.Pages.Publishers
{
    public class CreateModel : PageModel
    {
        private readonly Ghiriti_Edmond_Lab2.Data.Ghiriti_Edmond_Lab2Context _context;

        public CreateModel(Ghiriti_Edmond_Lab2.Data.Ghiriti_Edmond_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Publisher Publisher { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Publisher == null || Publisher == null)
            {
                return Page();
            }

            _context.Publisher.Add(Publisher);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
