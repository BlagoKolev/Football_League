namespace FootballLeague.Services.Contracts
{
    public interface ILeagueService
    {
        Task<int> CreateLeague(string leagueName);
        Task<int> GenerateFixtures(string leagueName);
    }
}
