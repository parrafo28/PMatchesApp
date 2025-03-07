using Microsoft.EntityFrameworkCore;
using PMatches.Domain.Entities; 

namespace PMatches.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
