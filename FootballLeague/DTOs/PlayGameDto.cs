using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FootballLeague.DTOs
{
    public class PlayGameDto
    {
        public int Id { get; set; }
        public int HomeId { get; set; }
        public int GuestId { get; set; }
        public byte HomeScore { get; set; }
        public byte GuestScore { get; set; }

        public int RoundNumber { get; set; }

        public bool IsPlayed { get; set; }

        public int LeagueId { get; set; }
    }
}
