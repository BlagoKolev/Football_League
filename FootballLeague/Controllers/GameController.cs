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
        public async Task<IActionResult> AutoPlayAllSeason(string leagueName)
        {
            var a =  await gameService.AutoPlayAllSeason(leagueName);

            return Ok();
        }
    }
}
