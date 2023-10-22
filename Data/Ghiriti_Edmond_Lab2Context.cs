using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ghiriti_Edmond_Lab2.Models;

namespace Ghiriti_Edmond_Lab2.Data
{
    public class Ghiriti_Edmond_Lab2Context : DbContext
    {
        public Ghiriti_Edmond_Lab2Context (DbContextOptions<Ghiriti_Edmond_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Ghiriti_Edmond_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Ghiriti_Edmond_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Ghiriti_Edmond_Lab2.Models.Author>? Author { get; set; }
    }
}
