using FootballLeague.Data.Entities;
using FootballLeague.Data;
using FootballLeague.Services;
using FootballLeague.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Test.Services
{
    public class LeagueServiceTest
    {
        private readonly Mock<ILeagueService> leagueServiceMock;
        public LeagueServiceTest()
        {
            leagueServiceMock = new Mock<ILeagueService>();
        }

        [Fact]
        public async Task CreateLeague_Returns_NewlyCreatedLeagueId()
        {
            leagueServiceMock.Setup(x => x.CreateLeague(It.IsAny<string>())).ReturnsAsync(1);

            var leagueService = leagueServiceMock.Object;

            var result = await leagueService.CreateLeague("Test");
            Assert.Equal(1, result);
        }

    }
}
