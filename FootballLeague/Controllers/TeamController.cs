using FootballLeague.DTOs;
using FootballLeague.Helper;
using FootballLeague.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService teamService;

        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpPut]
        [Route("change-name")]
        public async Task<IActionResult> ChangeTeamName([FromBody] TeamChangeNameDto input)
        {
            try
            {
                var result = await teamService.ChangeTeamName(input);

                if (result < 0)
                {
                    return BadRequest("League or Team does not exists.");
                }
                return Ok($"You have successfully change team name from '{input.CurrentTeamName}' to '{input.NewTeamName}'");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Constants.ErrorProcessingRequest);
            }

        }
    }
}
