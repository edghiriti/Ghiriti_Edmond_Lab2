using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ghiriti_Edmond_Lab2.Data;
using Ghiriti_Edmond_Lab2.Models;

namespace Ghiriti_Edmond_Lab2.Pages.Books
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
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            //ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FirstName");
            //ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "LastName");
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>()
            .Select(a => new { a.ID, FullName = a.FirstName + " " + a.LastName }), "ID", "FullName");

            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Book == null || Book == null)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
