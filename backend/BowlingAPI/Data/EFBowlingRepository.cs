using Microsoft.EntityFrameworkCore;

namespace BowlingAPI.Data
{
    public class EFBowlingRepository : IBowlingRepository // EFBowlingRepository is implementing from IBowlingRepository
    {
        private BowlingDbContext _context;

        public EFBowlingRepository(BowlingDbContext temp) // Constructor that requires context 
        {
            _context = temp;
        }

        public IEnumerable<Bowler> Bowlers => _context.Bowlers
            .Include(t => t.Team);

        public IEnumerable<Team> Teams => _context.Teams;

    }
}