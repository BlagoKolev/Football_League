using FootballLeague.Data;
using FootballLeague.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueService leagueService;
        private readonly ITeamService teamService;

        public LeagueController(ILeagueService leagueService, ITeamService teamService)
        {
            this.leagueService = leagueService;
            this.teamService = teamService;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] string leagueName)
        {
            try
            {
                var newLeagueId = await this.leagueService.CreateLeague(leagueName);

                if (newLeagueId == null)
                {
                    return BadRequest($"The {leagueName} was not created successfully");
                }

                var teamsResult = await this.teamService.GenerateTeams(newLeagueId);

                if (teamsResult > 0) 
                {
                    return Ok($"The {leagueName} league was created successfully");
                }

                return BadRequest($"The {leagueName} was not created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
