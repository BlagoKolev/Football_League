namespace FootballLeague.Services.Contracts
{
    public interface IGameService
    {
        Task<bool> AutoPlayAllSeason(string leagueName);
    }
}
