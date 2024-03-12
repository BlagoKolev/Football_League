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
        [Route("get-league-statistics-by-name")]
        public async Task<IActionResult> GetLeagueByName(string leagueName)
        {
            try
            {
                var leagueStatistics = await  statistiService.GetLeagueByName(leagueName);

                if (leagueStatistics != null)
                {
                    return Ok(leagueStatistics);
                }
                return BadRequest("We do not have statistic for {leagueName} league");
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException();
            }
           
        }
    }
}
