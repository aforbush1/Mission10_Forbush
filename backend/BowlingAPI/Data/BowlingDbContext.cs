using Microsoft.EntityFrameworkCore;

namespace BowlingAPI.Data
{
    public class BowlingDbContext: DbContext
    {
        public BowlingDbContext(DbContextOptions<BowlingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
