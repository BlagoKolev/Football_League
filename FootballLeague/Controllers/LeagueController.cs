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

        public LeagueController(ILeagueService leagueService)
        {
            this.leagueService = leagueService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string leagueName)
        {
            try
            {
                var result = await this.leagueService.CreateLeague(leagueName);

                if (result > 0) 
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
