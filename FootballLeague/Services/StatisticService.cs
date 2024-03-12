﻿using FootballLeague.Data;
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

        public async Task<LeagueByNameDto> GetPlayedGames(string leagueName)
        {
            var isLeagueExist = CheckIfLeagueExists(leagueName);

            if (!isLeagueExist)
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
                    })
                     .ToArray()
                })
                .FirstOrDefaultAsync();
            return league;
        }

        private bool CheckIfLeagueExists(string leagueName)
        {
            var league = this.db.Leagues
               .Where(league => league.Name == leagueName)
               .FirstOrDefault();
            return league != null ? true : false;
        }
    }
}
