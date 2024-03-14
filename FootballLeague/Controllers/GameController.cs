using FootballLeague.Helper;
using FootballLeague.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet]
        [Route("autoplay-season")]
        public IActionResult AutoPlayAllSeason(string leagueName)
        {
            try
            {
                var result = gameService.AutoPlayAllSeason(leagueName);

                if (result < 0)
                {
                    return BadRequest(Constants.LeagueNotFound);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Constants.ErrorProcessingRequest);
            }

        }
    }
}
