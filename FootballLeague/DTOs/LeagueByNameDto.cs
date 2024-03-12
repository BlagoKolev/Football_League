namespace FootballLeague.DTOs
{
    public class LeagueByNameDto
    {
        public LeagueByNameDto()
        {
            this.Standings = new List<TeamDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TeamDto> Standings { get; set; }
    }
}
