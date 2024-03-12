using FootballLeague.Data.Contracts;

namespace FootballLeague.Services.Contracts
{
    public interface ITeamService
    {
        Task<int> GenerateTeams(int leagueId);
    }
}
