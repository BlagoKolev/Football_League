using FootballLeague.Data;
using FootballLeague.Data.Entities;
using FootballLeague.DTOs;
using FootballLeague.Helper;
using FootballLeague.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Services
{
    public class GameService : IGameService
    {
        private readonly LeagueDbContext db;

        public GameService(LeagueDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> AutoPlayAllSeason(string leagueName)
        {
            var currentLeague = GetLeagueByName(leagueName);

            var gamesToBePlayed = await GetGamesToPlay(currentLeague.Id);

            PlayGame(gamesToBePlayed);




            return true;
        }

        private League GetLeagueByName(string leagueName)
        {
            return this.db.Leagues.Where(x => x.Name == leagueName).FirstOrDefault();
        }
        private async Task<List<PlayGameDto>> GetGamesToPlay(int leagueId)
        {
            var games = await this.db.Games
                .Where(x => x.LeagueId == leagueId && !x.IsPlayed)
                .Select(x => new PlayGameDto
                {
                    Id = x.Id,
                    HomeId = x.HomeId,
                    GuestId = x.GuestId,
                    HomeScore = x.HomeScore,
                    GuestScore = x.GuestScore,
                    IsPlayed = x.IsPlayed,
                    LeagueId = x.LeagueId,
                    RoundNumber = x.RoundNumber
                })
                .OrderBy(x => x.RoundNumber)
                .ToListAsync();

            return games;
        }

        private byte GetRandomScore()
        {
            var random = new Random();
            var score = (byte)random.Next(1, 5);
            return score;
        }

        private async void PlayGame(List<PlayGameDto> gamesToBePlayed)
        {

            for (int i = 0; i < gamesToBePlayed.Count; i++)
            {
                var homeScore = GetRandomScore();
                var guestScore = GetRandomScore();

                var currentGame = gamesToBePlayed[i];

                currentGame.HomeScore = homeScore;
                currentGame.GuestScore = guestScore;
                currentGame.IsPlayed = true;

                var updateGamesResult = UpdateGamesEntity(currentGame);
                var updateTeamsResul = UpdateTeamEntity(currentGame);

            }

        }

        private int UpdateGamesEntity(PlayGameDto currentGame)
        {
            var gameEntity = this.db.Games
                .Where(x => x.Id == currentGame.Id)
                .FirstOrDefault();

            if (gameEntity != null)
            {
                gameEntity.HomeScore = currentGame.HomeScore;
                gameEntity.GuestScore = currentGame.GuestScore;
                gameEntity.IsPlayed = currentGame.IsPlayed;
            }
            return this.db.SaveChanges();
        }

        private int UpdateTeamEntity(PlayGameDto currentGame)
        {
            var homeTeamEntity = this.db.Teams
                .Where(x => x.Id == currentGame.HomeId)
                .FirstOrDefault();

            var guestTeamEntity = this.db.Teams
                .Where(x => x.Id == currentGame.GuestId)
                .FirstOrDefault();

            if (homeTeamEntity != null && guestTeamEntity != null)
            {
                homeTeamEntity.GoalsScored += currentGame.HomeScore;
                homeTeamEntity.GoalsEarned += currentGame.GuestScore;

                guestTeamEntity.GoalsScored += currentGame.GuestScore;
                guestTeamEntity.GoalsEarned += currentGame.HomeScore;

                if (currentGame.HomeScore > currentGame.GuestScore)
                {
                    homeTeamEntity.Wins += 1;
                    homeTeamEntity.Points += Constants.WinPoints;

                    guestTeamEntity.Loses += 1;
                }
                else if (currentGame.GuestScore > currentGame.HomeScore)
                {
                    guestTeamEntity.Wins += 1;
                    guestTeamEntity.Points += Constants.WinPoints;

                    homeTeamEntity.Loses += 1;
                }
                else if (currentGame.HomeScore == currentGame.GuestScore)
                {
                    homeTeamEntity.Draws += 1;
                    homeTeamEntity.Points += Constants.DrawPoints;

                    guestTeamEntity.Draws += 1;
                    guestTeamEntity.Points += Constants.DrawPoints;
                }
            }

            return this.db.SaveChanges();
        }
    }
}