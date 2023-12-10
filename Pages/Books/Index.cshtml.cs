using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ghiriti_Edmond_Lab2.Data;
using Ghiriti_Edmond_Lab2.Models;
using System.Net;

namespace Ghiriti_Edmond_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Ghiriti_Edmond_Lab2.Data.Ghiriti_Edmond_Lab2Context _context;

        public IndexModel(Ghiriti_Edmond_Lab2.Data.Ghiriti_Edmond_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookD = new BookData();
            if (_context.Book != null)
            {
                Book = await _context.Book
                    .Include(b => b.Publisher)
                    .Include(b => b.Author)
                    .ToListAsync();
            }

            BookD.Books = await _context.Book
    .Include(b => b.Publisher)
    .Include(b => b.BookCategories)
        .ThenInclude(b => b.Category)
    .AsNoTracking()
    .OrderBy(b => b.Title)
    .ToListAsync();

            if (id != null)
            {
                BookID = id.Value;
                Book book = BookD.Books
                    .Where(i => i.ID == id.Value).Single();

                BookD.Categories = book.BookCategories.Select(s => s.Category);
            }

        }
    }
}
