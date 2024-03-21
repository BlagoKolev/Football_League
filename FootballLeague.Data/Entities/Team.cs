using FootballLeague.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Entities
{
    public class Team : ITeamPrototype
    {
        public Team()
        {
            this.HomeGames = new List<Games>();
            this.GuestGames = new List<Games>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Invalid Name length", MinimumLength = 3)]
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

        [InverseProperty("HomeTeam")]
        public virtual ICollection<Games> HomeGames { get; set; }
        [InverseProperty("GuestTeam")]
        public virtual ICollection<Games> GuestGames { get; set; }
        public ITeamPrototype Clone()
        {
            return (ITeamPrototype)this.MemberwiseClone();
        }
    }
}
