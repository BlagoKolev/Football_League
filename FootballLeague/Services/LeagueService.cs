using FootballLeague.Data;
using FootballLeague.Data.Entities;
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
            //var leagues = this.db.Leagues
            //    .Where(league => league.Name == leagueName)
            //    .ToArray();

            //if (leagues.Any())
            //{
            //    return -1;
            //}

            var newLeague = new League
            {
                Name = leagueName,
            };

            await db.Leagues.AddAsync(newLeague);
            await db.SaveChangesAsync();
            return newLeague.Id;
        }
    }
}
