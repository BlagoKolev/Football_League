namespace FootballLeague.DTOs
{
    public class LeagueByNameDto
    {
        public LeagueByNameDto()
        {
            this.Standings = new List<TeamDto>();
            this.Results = new List<ResultDto>();
            this.Fixtures = new List<FixturesDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TeamDto> Standings { get; set; }
        public ICollection<ResultDto> Results { get; set; }
        public ICollection<FixturesDto> Fixtures { get; set; }

    }
}
