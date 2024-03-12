﻿// <auto-generated />
using FootballLeague.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FootballLeague.Data.Migrations
{
    [DbContext(typeof(LeagueDbContext))]
    [Migration("20240312090724_AddLeagueIdToTeamAndAddValidations")]
    partial class AddLeagueIdToTeamAndAddValidations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FootballLeague.Data.Entities.Games", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<byte>("GuestScore")
                        .HasColumnType("tinyint");

                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.Property<byte>("HomeScore")
                        .HasColumnType("tinyint");

                    b.Property<bool>("IsPlayed")
                        .HasColumnType("bit");

                    b.Property<byte>("RoundNumber")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("FootballLeague.Data.Entities.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("FootballLeague.Data.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte>("Draws")
                        .HasColumnType("tinyint");

                    b.Property<byte>("GoalsEarned")
                        .HasColumnType("tinyint");

                    b.Property<byte>("GoalsScored")
                        .HasColumnType("tinyint");

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<byte>("Loses")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<byte>("Points")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Strength")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Wins")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
