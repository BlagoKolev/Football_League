namespace FootballLeague.DTOs
{
    public class ResultDto
    {
        public int Id { get; set; }
        public string? HomeName { get; set; }
        public byte HomeScore { get; set; }
        public string? GuestName { get; set; }
        public int GuestScore { get; set; }
        public int RoundNumber { get; set; }
    }
}
