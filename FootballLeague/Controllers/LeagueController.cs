using FootballLeague.Data;
using FootballLeague.Helper;
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
                    return BadRequest(Constants.LeagueCreationFailed);
                }
                else if (newLeagueId < 0)
                {
                    return BadRequest($"The League with name {leagueName} alread exists. Please choose another name.");
                }

                var teamsResult = await this.teamService.GenerateTeams(newLeagueId);

                if (teamsResult > 0)
                {
                    return Ok(Constants.LeagueCreationSuccessfull);
                }

                return BadRequest(Constants.LeagueCreationFailed);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Constants.ErrorProcessingRequest);
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
                    case > 0: return Ok(Constants.FixturesForLeagueCreatedSuccessfully); break;
                    case -1: return BadRequest(Constants.LeagueNotFound); break;
                    case -2: return BadRequest(Constants.LeagueAlreadyHasFixturesCreated); break;
                    default:
                        return BadRequest();
                        break;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Constants.ErrorProcessingRequest);
            }

        }
    }
}
