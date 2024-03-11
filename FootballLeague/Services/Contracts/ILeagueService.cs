namespace FootballLeague.Services.Contracts
{
    public interface ILeagueService
    {
        Task<int> CreateLeague(string leagueName);
    }
}
