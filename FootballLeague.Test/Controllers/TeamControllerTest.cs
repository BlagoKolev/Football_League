using FootballLeague.Controllers;
using FootballLeague.DTOs;
using FootballLeague.Helper;
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
    public class TeamControllerTest
    {
        private readonly TeamController teamController;
        private readonly Mock<ITeamService> teamServiceMock;

        public TeamControllerTest()
        {
            teamServiceMock = new Mock<ITeamService>();
            teamController = new TeamController(teamServiceMock.Object);
        }

        [Fact]
        public async Task ChangeTeamName_Return_BadReques_If_Result_Is_NegativeNumber()
        {
            var input = new TeamChangeNameDto() { LeagueName="Test", CurrentTeamName = "TestOldName", NewTeamName="TestNewName" };

            teamServiceMock.Setup(x => x.ChangeTeamName(It.IsAny<TeamChangeNameDto>())).ReturnsAsync(-1);

            var result = await teamController.ChangeTeamName(input) as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal(Constants.LeagueOrTeamNotExist, result.Value);
        }
    }
}
