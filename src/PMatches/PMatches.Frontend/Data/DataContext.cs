using Microsoft.EntityFrameworkCore;
using PMatches.Frontend.Data.Entities;

namespace PMatches.Frontend.Data
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
