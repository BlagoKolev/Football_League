using FootballLeague.Data;
using FootballLeague.Data.Contracts;
using FootballLeague.Data.Entities;
using FootballLeague.Services.Contracts;

namespace FootballLeague.Services
{
    public class TeamService : ITeamService
    {
        private readonly LeagueDbContext db;

        public TeamService(LeagueDbContext db)
        {
            this.db = db;
        }
        public async Task<int> GenerateTeams(int leagueId)
        {
            var teamsList = new List<ITeamPrototype>();

            var originalTeam = new Team
            {
                Name = "Team-1",
                LeagueId = leagueId
            };

            teamsList.Add(originalTeam);

            for (int i = 0; i < 9; i++)
            {
                var clonedTeam = (Team)originalTeam.Clone();
                clonedTeam.Name = $"Team-{i+2}";
                teamsList.Add(clonedTeam);
            }

           await db.AddRangeAsync(teamsList);
            var result = await db.SaveChangesAsync();
            return result;
        }
    }
}
