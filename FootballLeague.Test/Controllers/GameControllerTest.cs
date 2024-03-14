using FootballLeague.Controllers;
using FootballLeague.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Test.Controllers
{
    public class GameControllerTest
    {
        private readonly Mock<IGameService> gameServiceMock;
        private readonly GameController gameController;
        public GameControllerTest()
        {
            gameServiceMock = new Mock<IGameService>();
            gameController = new GameController(gameServiceMock.Object);
        }


        [Fact]
        public void AutoPlayAllSeason_ValidLeagueName_Returns_Ok200()
        {
            gameServiceMock.Setup(m => m.AutoPlayAllSeason(It.IsAny<string>())).Returns(1);

            var result = gameController.AutoPlayAllSeason("TestLeague");

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void AutoPlayAllSeason_InValidLeagueName_Returns_BadRequest()
        {
            gameServiceMock.Setup(m => m.AutoPlayAllSeason(It.IsAny<string>())).Returns(-1);

            var result = gameController.AutoPlayAllSeason("TestLeague");

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void AutoPlayAllSeason_If_ServiceThrowsException_Returns_InternalServerError()
        {
            gameServiceMock.Setup(m => m.AutoPlayAllSeason(It.IsAny<string>())).Throws<Exception>();
           
            var result = gameController.AutoPlayAllSeason("TestLeague");


            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
    }
}
