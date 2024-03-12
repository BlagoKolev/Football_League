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
                else if (newLeagueId < 0)
                {
                    return BadRequest($"The League with name {leagueName} alread exists. Please choose another name.");
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

        [HttpPost]
        [Route("Generate-Fixtures")]
        public async Task<IActionResult> GenerateFixtures(string leagueName)
        {
            try
            {
                var result = await leagueService.GenerateFixtures(leagueName);

                switch (result)
                {
                    case > 0: return Ok($"Fixtures for {leagueName} league was created. Please proceed with playing maches."); break;
                    case -1: return BadRequest($"League with name {leagueName} does not exist."); break;
                    case -2: return BadRequest($"League with name {leagueName} already has Fixtures created."); break;
                    default: return BadRequest();
                        break;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
