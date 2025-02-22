using Microsoft.EntityFrameworkCore;

namespace PMatches.Frontend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<PMatches.Frontend.Models.Match> Matches { get; set; }
    }
}
