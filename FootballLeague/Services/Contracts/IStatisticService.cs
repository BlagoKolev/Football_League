using FootballLeague.DTOs;

namespace FootballLeague.Services.Contracts
{
    public interface IStatisticService
    {
        Task<ICollection<GetLeagueDto>> GetAllLeagues();
        Task<LeagueByNameDto> GetLeagueByName(string leagueName);
        Task<LeagueByNameDto> GetPlayedGames(string leagueName);
        Task<LeagueByNameDto> GetFixtures(string leagueName);
    }
}
