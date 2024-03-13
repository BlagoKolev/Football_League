using FootballLeague.DTOs;
using FootballLeague.Helper;
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
                return NotFound("We don`t have any existing Leagues at this moment. You can try to Create your own League in the League section.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Constants.ErrorProcessingRequest);
            }
        }

        [HttpGet]
        [Route("get-league-standings-by-name")]
        public async Task<IActionResult> GetLeagueByName(string leagueName)
        {
            try
            {
                var leagueStatistics = await statistiService.GetLeagueByName(leagueName);

                if (leagueStatistics != null)
                {
                    return Ok(leagueStatistics);
                }
                return NotFound($"We do not have statistic for {leagueName} league");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Constants.ErrorProcessingRequest);
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
                    return NotFound(Constants.LeagueNotFound);
                }
                else if (!leaguePlayedGames.Results.Any())
                {
                    return NotFound($"Season in {leagueName} league still not started.");
                }

                return Ok(leaguePlayedGames);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Constants.ErrorProcessingRequest);
            }
        }

        [HttpGet]
        [Route("get-league-fixtures")]
        public async Task<IActionResult> GetLeagueFixtures(string leagueName)
        {
            try
            {
                var fixtures = await statistiService.GetFixtures(leagueName);

                if (fixtures == null)
                {
                    return NotFound(Constants.LeagueNotFound);
                }
                else if (!fixtures.Fixtures.Any() && fixtures.Results.Any())
                {
                    return NotFound($"The {leagueName} league has completed and no more games to be played.");     
                }
                else if (!fixtures.Fixtures.Any())
                {
                    return NotFound("This league has no Fixtures created. Please Create one from League section.");
                }

                return Ok(fixtures);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Constants.ErrorProcessingRequest);
            }
        }
    }
}
