using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Entities
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public byte Strength { get; set; }
        public byte Points { get; set; } = 0;
        public byte GoalsScored { get; set; } = 0;
        public byte GoalsEarned { get; set; } = 0;
        public byte Wins { get; set; } = 0;
        public byte Loses { get; set; } = 0;
        public byte Draws { get; set; } = 0;
    }
}
