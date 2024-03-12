using FootballLeague.Data;
using FootballLeague.Data.Entities;
using FootballLeague.DTOs;
using FootballLeague.Services.Contracts;

namespace FootballLeague.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly LeagueDbContext db;

        public LeagueService(LeagueDbContext db)
        {
            this.db = db;
        }
        public async Task<int> CreateLeague(string leagueName)
        {
            var league = CheckIfLeagueExists(leagueName);

            if (league != null)
            {
                return -1;
            }

            var newLeague = new League
            {
                Name = leagueName,
            };

            await this.db.Leagues.AddAsync(newLeague);
            await this.db.SaveChangesAsync();
            return newLeague.Id;
        }

        public async Task<int> GenerateFixtures(string leagueName)
        {
            var league = CheckIfLeagueExists(leagueName);

            if (league == null) { return -1; }

            var teams = GetTeams(league.Id);
            var teamsIds = teams.Select(x => x.Id).ToList();
            var numberOfRounds = teams.Count - 1;

            var fixtures = new List<Games>();

            //Create games for every round
            for (int i = 0; i < numberOfRounds; i++)
            {
                //Stack first Team in the colletion with the last team in the collectio
                for (int j = 0; j < teams.Count / 2; j++)
                {
                    var homeTeamId = teamsIds[j];
                    var awayTeamId = teamsIds[teamsIds.Count - 1 - j];

                    //Shuffle home and away 
                    if (i % 2 == 1)
                    {
                        var temp = homeTeamId;
                        homeTeamId = awayTeamId;
                        awayTeamId = temp;
                    }
                    //Create a game for 1st half of the season
                    var homeGame = new Games
                    {
                        HomeId = homeTeamId,
                        GuestId = awayTeamId,
                        RoundNumber = i + 1,
                        LeagueId = league.Id
                    };
                    //Create the same game for 2nd half of the season but with exchanged visits
                    var awayGame = new Games
                    {
                        HomeId = awayTeamId,
                        GuestId = homeTeamId,
                        RoundNumber = i + teams.Count,
                        LeagueId = league.Id
                    };
                   

                    //Add the games in the collection of Fixtures 
                    fixtures.Add(homeGame);
                    fixtures.Add(awayGame);
                }

                //Swap the second element in the teams collection with the last element and continue to itterate over collection
                teamsIds.Insert(1, teamsIds[teamsIds.Count - 1]);
                teamsIds.RemoveAt(teams.Count);

            }

            await this.db.AddRangeAsync(fixtures);
            var result = await this.db.SaveChangesAsync();
            return result;

        }

        private League CheckIfLeagueExists(string leagueName)
        {
            return this.db.Leagues
               .Where(league => league.Name == leagueName)
               .FirstOrDefault();
        }

        private ICollection<TeamDto> GetTeams(int leagueId)
        {
            var teams = this.db.Teams
                .Where(x => x.LeagueId == leagueId)
                .Select(t => new TeamDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Strength = t.Strength,
                    Points = t.Points,
                    GoalsScored = t.GoalsScored,
                    GoalsEarned = t.GoalsEarned,
                    Wins = t.Wins,
                    Loses = t.Loses,
                    Draws = t.Draws,
                    LeagueId = t.LeagueId
                })
                .ToList();
            return teams;
        }
    }
}
