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
            var leagues =  await this.db.Leagues
                .Select(x=> new GetLeagueDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            return leagues;
        }
    }
}
