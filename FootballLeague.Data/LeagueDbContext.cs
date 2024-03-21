using FootballLeague.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballLeague.Data
{
    public class LeagueDbContext : DbContext
    {
        public LeagueDbContext(DbContextOptions<LeagueDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<League>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<Games>()
                 .HasOne(m => m.HomeTeam)
                 .WithMany(t => t.HomeGames)
                 .HasForeignKey(m => m.HomeId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Games>()
                 .HasOne(m => m.GuestTeam)
                 .WithMany(t => t.GuestGames)
                 .HasForeignKey(m => m.GuestId)
                 .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<League>? Leagues { get; set; }
        public DbSet<Team>? Teams { get; set; }
        public DbSet<Games>? Games { get; set; }
    }
}
