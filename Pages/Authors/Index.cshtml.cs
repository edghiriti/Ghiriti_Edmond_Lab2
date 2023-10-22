using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ghiriti_Edmond_Lab2.Data;
using Ghiriti_Edmond_Lab2.Models;

namespace Ghiriti_Edmond_Lab2.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Ghiriti_Edmond_Lab2.Data.Ghiriti_Edmond_Lab2Context _context;

        public IndexModel(Ghiriti_Edmond_Lab2.Data.Ghiriti_Edmond_Lab2Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Author != null)
            {
                Author = await _context.Author.ToListAsync();
            }
        }
    }
}
