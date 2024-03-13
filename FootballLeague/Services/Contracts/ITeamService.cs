using FootballLeague.Data.Contracts;
using FootballLeague.DTOs;

namespace FootballLeague.Services.Contracts
{
    public interface ITeamService
    {
        Task<int> GenerateTeams(int leagueId);
        Task<int> ChangeTeamName(TeamChangeNameDto input);
    }
}
