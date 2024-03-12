using FootballLeague.Data;
using FootballLeague.DTOs;
using FootballLeague.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly LeagueDbContext db;

        public StatisticService(LeagueDbContext db)
        {
            this.db = db;
        }
        public async Task<ICollection<GetLeagueDto>> GetAllLeagues()
        {
            var leagues = await this.db.Leagues
                .Select(x => new GetLeagueDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            return leagues;
        }

        public async Task<LeagueByNameDto> GetLeagueByName(string leagueName)
        {
            var league = await this.db.Leagues
                .Where(x => x.Name == leagueName)
                .Select(x => new LeagueByNameDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Standings = x.Teams
                        .Select(x => new TeamDto
                        {
                            Name = x.Name,
                            Points = x.Points,
                            Wins = x.Wins,
                            Draws = x.Draws,
                            Loses = x.Loses,
                            GoalsScored = x.GoalsScored,
                            GoalsEarned = x.GoalsEarned
                        })
                        .OrderByDescending(x => x.Points)
                        .ToArray()
                })
                .FirstOrDefaultAsync();

            return league;
        }
    }
}
