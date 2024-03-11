using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Entities
{
    public class League
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
