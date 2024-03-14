namespace BowlingAPI.Data
{
    public interface IBowlingRepository // Interface which is a template for all of the classes. 
    {
        // This makes sure that the interface template includes Bowlers and Teams
        IEnumerable<Bowler> Bowlers { get; }

        IEnumerable<Team> Teams { get; }

    }
}