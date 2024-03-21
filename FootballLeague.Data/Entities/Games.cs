using FootballLeague.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Entities
{
    public class Games
    {
        public Games()
        {

        }
        [Key]
        public int Id { get; set; }
        //[ForeignKey("TeamId")]
        [Required]
        public int HomeId { get; set; }
       // [ForeignKey("TeamId")]
        [Required]
        public int GuestId { get; set; }
        public byte HomeScore { get; set; }
        public byte GuestScore { get; set; }
        [Required]
        public int RoundNumber { get; set; }
        [Required]
        public bool IsPlayed { get; set; }
        [Required]
        public int LeagueId { get; set; }
        public League league { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team GuestTeam { get; set; }
    }
}

