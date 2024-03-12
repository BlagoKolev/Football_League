using FootballLeague.DTOs;
using FootballLeague.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService statistiService;

        public StatisticController(IStatisticService statistiService)
        {
            this.statistiService = statistiService;
        }

        [HttpGet]
        [Route("all-leagues")]
        public async Task<IActionResult> GetAllLeagues()
        {
            try
            {
                var existingLeagues = await statistiService.GetAllLeagues();
                if (existingLeagues.Count > 0)
                {
                    return Ok(existingLeagues);
                }
                return BadRequest("We don`t have any existing Leagues at this moment. You can try to Create your own League in the League section.");
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry something went wrong");
            }
        }

        [HttpGet]
        [Route("get-league-standings-by-name")]
        public async Task<IActionResult> GetLeagueByName(string leagueName)
        {
            try
            {
                var leagueStatistics = await  statistiService.GetLeagueByName(leagueName);

                if (leagueStatistics != null)
                {
                    return Ok(leagueStatistics);
                }
                return BadRequest($"We do not have statistic for {leagueName} league");
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException();
            }
           
        }

        [HttpGet]
        [Route("get-league-played-games")]
        public async Task<IActionResult> GetPlayedGames(string leagueName)
        {
            try
            {
                var leaguePlayedGames = await statistiService.GetPlayedGames(leagueName);
                if (leaguePlayedGames == null)
                {
                    return BadRequest($"League with name {leagueName} does not exist.");
                }
                else if (!leaguePlayedGames.Results.Any())
                {
                    return Ok($"The {leagueName} league is not started yet.");
                }
                return Ok(leaguePlayedGames);
            }
            catch (Exception)
            {
                throw new InvalidOperationException();                
            }
        }
    }
}
