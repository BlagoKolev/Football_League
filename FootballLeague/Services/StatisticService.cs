using FootballLeague.Data;
using FootballLeague.Data.Entities;
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

        public async Task<LeagueByNameDto> GetFixtures(string leagueName)
        {
            var league = CheckIfLeagueExists(leagueName);

            if (league == null)
            {
                return null;
            }

            var fixtures = await this.db.Leagues
                .Where(x => x.Name == leagueName)
                .Select(x => new LeagueByNameDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Fixtures = x.Games
                    .Where(x => !x.IsPlayed)
                        .Select(x => new FixturesDto
                        {
                            RoundId = x.RoundNumber,
                            HomeName = this.db.Teams.FirstOrDefault(t => t.Id == x.HomeId).Name,
                            GuestName = this.db.Teams.FirstOrDefault(t => t.Id == x.GuestId).Name,
                        })
                        .OrderBy(x => x.RoundId)
                        .ToArray(),
                //    Results = x.Games
                //    .Select(x => new ResultDto
                //    {
                //        Id = x.Id
                //    })
                //.ToArray()
                })
                .FirstOrDefaultAsync();

            return fixtures;
        }

        public async Task<LeagueByNameDto> GetLeagueByName(string leagueName)
        {
            var league = CheckIfLeagueExists(leagueName);

            var standings = await this.db.Leagues
                .Where(x => x.Name == leagueName)
                .Select(x => new LeagueByNameDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Standings = x.Teams
                        .Select(x => new TeamDto
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Points = x.Points,
                            Wins = x.Wins,
                            Draws = x.Draws,
                            Loses = x.Loses,
                            GoalsScored = x.GoalsScored,
                            GoalsEarned = x.GoalsEarned,
                            LeagueId = x.LeagueId
                        })
                        .OrderByDescending(x => x.Points)
                        .ThenByDescending(x => x.GoalsScored)
                        .ToArray()
                })
                .FirstOrDefaultAsync();

            return standings;
        }

        public async Task<LeagueByNameDto> GetPlayedGames(string leagueName)
        {
            var leagueDb = CheckIfLeagueExists(leagueName);

            if (leagueDb == null)
            {
                return null;
            }

            var league = await this.db.Leagues
                .Where(l => l.Name == leagueName)
                .Select(x => new LeagueByNameDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Results = x.Games
                    .Where(x => x.IsPlayed)
                    .Select(x => new ResultDto
                    {
                        Id = x.Id,
                        HomeName = this.db.Teams.FirstOrDefault(t => t.Id == x.HomeId).Name,
                        HomeScore = x.HomeScore,
                        GuestName = this.db.Teams.FirstOrDefault(t => t.Id == x.GuestId).Name,
                        GuestScore = x.GuestScore,
                        RoundNumber = x.RoundNumber
                    })
                    .OrderBy(x => x.RoundNumber)
                     .ToArray()
                })
                .FirstOrDefaultAsync();
            return league;
        }
        private League CheckIfLeagueExists(string leagueName)
        {
            var league = this.db.Leagues
               .Where(league => league.Name == leagueName)
               .FirstOrDefault();
            return league;
        }
    }
}
