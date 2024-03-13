using FootballLeague.Controllers;
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
    public class LeagueControllerTests
    {
        private readonly Mock<ILeagueService> leagueServiceMock;
        private readonly Mock<ITeamService> teamServiceMock;
        private readonly LeagueController leagueController;
        public LeagueControllerTests()
        {
            leagueServiceMock = new Mock<ILeagueService>();
            teamServiceMock = new Mock<ITeamService>();
            leagueController = new LeagueController(leagueServiceMock.Object, teamServiceMock.Object);
        }

        #region [Test Create method]
        [Fact]
        public async Task Create_ReturnsBadRequest_WhenLeagueNameIsNull()
        {
            var result = await leagueController.Create(null) as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal("The League was not created successfully", result.Value);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_If_ResultIs_NegativeNumber()
        {
            leagueServiceMock.Setup(x => x.CreateLeague(It.IsAny<string>())).ReturnsAsync(-1);

            var result = await leagueController.Create("Test") as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal("The League with name Test alread exists. Please choose another name.", result.Value);
        }

        [Fact]
        public async Task Create_Returns_BadRequest_IfGenerateTeams_Returns_NegativeNumber()
        {
            teamServiceMock.Setup(x => x.GenerateTeams(It.IsAny<int>())).ReturnsAsync(-1);

            var result = await leagueController.Create("Test") as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal("The League was not created successfully", result.Value);
        }

        [Fact]
        public async Task Create_Returns_Ok200_If_ResultIs_PositiveNumber()
        {
            teamServiceMock.Setup(x => x.GenerateTeams(It.IsAny<int>())).ReturnsAsync(1);

            var result = await leagueController.Create("Test") as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal("The League was created successfully", result.Value);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenTeamGenerationFails()
        {

            leagueServiceMock.Setup(s => s.CreateLeague(It.IsAny<string>())).ReturnsAsync(1);
            teamServiceMock.Setup(s => s.GenerateTeams(It.IsAny<int>())).ReturnsAsync(0);

            var result = await leagueController.Create("Premier League") as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal(Constants.LeagueCreationFailed, result.Value);
        }

        [Fact]
        public async Task Create_Returns_InternalServerError_WhenExceptionIsThrown_By_Service()
        {
            leagueServiceMock.Setup(x => x.CreateLeague(It.IsAny<string>())).Throws(new Exception());

            var result = await leagueController.Create("Test") as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
            Assert.Equal(Constants.ErrorProcessingRequest, result.Value);
        }

        #endregion

        #region [Test Create-Fixtures method]
        [Fact]
        public async Task GenerateFixtures_Return_200Ok_IfResult_Is_PositiveNumber()
        {
            leagueServiceMock.Setup(x => x.GenerateFixtures(It.IsAny<string>())).ReturnsAsync(1);

            var result = await leagueController.GenerateFixtures("Test") as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal("Fixtures for this League was created. Please proceed with playing maches.", result.Value);
        }

        [Fact]
        public async Task GenerateFixtures_Return_BadRequest_IfResult_Is_MinusOne()
        {
            leagueServiceMock.Setup(x => x.GenerateFixtures(It.IsAny<string>())).ReturnsAsync(-1);

            var result = await leagueController.GenerateFixtures("Test") as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal("League with such name does not exist.", result.Value);
        }

        [Fact]
        public async Task GenerateFixtures_Return_BadRequest_IfResult_Is_MinusTwo()
        {
            leagueServiceMock.Setup(x => x.GenerateFixtures(It.IsAny<string>())).ReturnsAsync(-2);

            var result = await leagueController.GenerateFixtures("Test") as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal("This League already has Fixtures created.", result.Value);
        }

        [Fact]
        public async Task Create_Returns_Ok200_WhenLeagueIsCreated_And_TeamsAreGenerated()
        {

            leagueServiceMock.Setup(s => s.CreateLeague(It.IsAny<string>())).ReturnsAsync(1);
            teamServiceMock.Setup(s => s.GenerateTeams(It.IsAny<int>())).ReturnsAsync(10);

            var result = await leagueController.Create("Premier League") as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal(Constants.LeagueCreationSuccessfull, result.Value);
        }

        
        #endregion
    }
}
