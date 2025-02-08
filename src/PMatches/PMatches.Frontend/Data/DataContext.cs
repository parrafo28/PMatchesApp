using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMatches.Frontend.Models;

namespace PMatches.Frontend.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<PMatches.Frontend.Models.Match> Match { get; set; } = default!;
    }
}
