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
    }
}
