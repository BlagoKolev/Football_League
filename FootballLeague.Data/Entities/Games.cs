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
        [Key]
        public int Id { get; set; }
        [ForeignKey("TeamId")]
        public int HomeId { get; set; }
        [ForeignKey("TeamId")]
        public int GuestId { get; set; }
        public byte HomeScore { get; set; }
        public byte GuestScore { get; set; }
        public byte RoundNumber { get; set; }
        public bool IsPlayed { get; set; }
    }
}

   