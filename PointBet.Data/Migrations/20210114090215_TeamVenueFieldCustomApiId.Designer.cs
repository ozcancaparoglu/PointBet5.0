﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PointBet.Data.Context;

namespace PointBet.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210114090215_TeamVenueFieldCustomApiId")]
    partial class TeamVenueFieldCustomApiId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("PointBet.Data.Domains.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Flag")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProcessedBy")
                        .HasColumnType("int");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("PointBet.Data.Domains.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ApiId")
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logo")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("ProcessedBy")
                        .HasColumnType("int");

                    b.Property<int?>("SeasonId")
                        .HasColumnType("int");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("SeasonId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("PointBet.Data.Domains.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Current")
                        .HasColumnType("bit");

                    b.Property<int>("CustomApiId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProcessedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("PointBet.Data.Domains.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ApiId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomApiId")
                        .HasColumnType("int");

                    b.Property<int?>("Founded")
                        .HasColumnType("int");

                    b.Property<int?>("LeagueId")
                        .HasColumnType("int");

                    b.Property<string>("Logo")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("National")
                        .HasColumnType("bit");

                    b.Property<int>("ProcessedBy")
                        .HasColumnType("int");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.HasIndex("VenueId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("PointBet.Data.Domains.TeamStatistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AwayCleanSheet")
                        .HasColumnType("int");

                    b.Property<int>("AwayDraw")
                        .HasColumnType("int");

                    b.Property<int>("AwayFailedToScore")
                        .HasColumnType("int");

                    b.Property<int>("AwayGoalsAgainst")
                        .HasColumnType("int");

                    b.Property<decimal>("AwayGoalsAgainstAverage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("AwayGoalsFor")
                        .HasColumnType("int");

                    b.Property<decimal>("AwayGoalsForAverage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("AwayLose")
                        .HasColumnType("int");

                    b.Property<int>("AwayPlayed")
                        .HasColumnType("int");

                    b.Property<int>("AwayWin")
                        .HasColumnType("int");

                    b.Property<int>("BiggestAwayGoalAgainst")
                        .HasColumnType("int");

                    b.Property<int>("BiggestAwayGoalFor")
                        .HasColumnType("int");

                    b.Property<string>("BiggestAwayLose")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("BiggestAwayWin")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("BiggestDrawStreak")
                        .HasColumnType("int");

                    b.Property<int>("BiggestHomeGoalAgainst")
                        .HasColumnType("int");

                    b.Property<int>("BiggestHomeGoalFor")
                        .HasColumnType("int");

                    b.Property<string>("BiggestHomeLose")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("BiggestHomeWin")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("BiggestLoseStreak")
                        .HasColumnType("int");

                    b.Property<int>("BiggestWinStreak")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Form")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("HomeCleanSheet")
                        .HasColumnType("int");

                    b.Property<int>("HomeDraw")
                        .HasColumnType("int");

                    b.Property<int>("HomeFailedToScore")
                        .HasColumnType("int");

                    b.Property<int>("HomeGoalsAgainst")
                        .HasColumnType("int");

                    b.Property<decimal>("HomeGoalsAgainstAverage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("HomeGoalsFor")
                        .HasColumnType("int");

                    b.Property<decimal>("HomeGoalsForAverage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("HomeLose")
                        .HasColumnType("int");

                    b.Property<int>("HomePlayed")
                        .HasColumnType("int");

                    b.Property<int>("HomeWin")
                        .HasColumnType("int");

                    b.Property<int?>("LeagueId")
                        .HasColumnType("int");

                    b.Property<int>("ProcessedBy")
                        .HasColumnType("int");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamStatistics");
                });

            modelBuilder.Entity("PointBet.Data.Domains.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Password")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ProcessedBy")
                        .HasColumnType("int");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PointBet.Data.Domains.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ProcessedBy")
                        .HasColumnType("int");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("PointBet.Data.Domains.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("ApiId")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("ProcessedBy")
                        .HasColumnType("int");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.Property<string>("Surface")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("PointBet.Data.Domains.League", b =>
                {
                    b.HasOne("PointBet.Data.Domains.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("PointBet.Data.Domains.Season", "Season")
                        .WithMany()
                        .HasForeignKey("SeasonId");

                    b.Navigation("Country");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("PointBet.Data.Domains.Team", b =>
                {
                    b.HasOne("PointBet.Data.Domains.League", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId");

                    b.HasOne("PointBet.Data.Domains.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId");

                    b.Navigation("League");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("PointBet.Data.Domains.TeamStatistic", b =>
                {
                    b.HasOne("PointBet.Data.Domains.League", "League")
                        .WithMany()
                        .HasForeignKey("LeagueId");

                    b.HasOne("PointBet.Data.Domains.Team", "Team")
                        .WithMany("TeamStatistics")
                        .HasForeignKey("TeamId");

                    b.Navigation("League");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("PointBet.Data.Domains.User", b =>
                {
                    b.HasOne("PointBet.Data.Domains.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("PointBet.Data.Domains.Venue", b =>
                {
                    b.HasOne("PointBet.Data.Domains.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("PointBet.Data.Domains.League", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("PointBet.Data.Domains.Team", b =>
                {
                    b.Navigation("TeamStatistics");
                });
#pragma warning restore 612, 618
        }
    }
}