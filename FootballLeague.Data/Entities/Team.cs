using FootballLeague.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Entities
{
    public class Team : ITeamPrototype
    {
        public Team()
        {
                this.Games = new List<Games>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30,ErrorMessage = "Invalid Name length", MinimumLength =3)]
        public string? Name { get; set; }
        [Required]
        public byte Strength { get; set; } = 0;
        [Required]
        public byte Points { get; set; } = 0;
        [Required]
        public byte GoalsScored { get; set; } = 0;
        [Required]
        public byte GoalsEarned { get; set; } = 0;
        [Required]
        public byte Wins { get; set; } = 0;
        [Required]
        public byte Loses { get; set; } = 0;
        [Required]
        public byte Draws { get; set; } = 0;
        [Required]
        public int LeagueId { get; set; }
        public League league { get; set; }

        public ICollection<Games> Games { get; set; }
        public ITeamPrototype Clone()
        {
            return (ITeamPrototype)this.MemberwiseClone();
        }
    }
}
