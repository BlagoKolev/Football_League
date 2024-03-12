using FootballLeague.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace FootballLeague.DTOs
{
    public class TeamDto
    {  
        public int Id { get; set; }
      
        public string? Name { get; set; }
       
        public byte Strength { get; set; } = 0;
       
        public byte Points { get; set; } = 0;
       
        public byte GoalsScored { get; set; } = 0;
       
        public byte GoalsEarned { get; set; } = 0;
        
        public byte Wins { get; set; } = 0;
       
        public byte Loses { get; set; } = 0;
        
        public byte Draws { get; set; } = 0;
       
        public int LeagueId { get; set; }
    }
}
