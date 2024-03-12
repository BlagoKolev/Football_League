using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Entities
{
    public class League
    {
        public League()
        {
            this.Teams = new List<Team>();
            this.Games = new List<Games>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Invalid Name length", MinimumLength = 3)]
        public string? Name { get; set; }
        public ICollection<Team> Teams { get; set; }
        public ICollection<Games> Games { get; set; }
    }
}
