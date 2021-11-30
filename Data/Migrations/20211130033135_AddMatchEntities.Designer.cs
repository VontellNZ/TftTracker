﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TftTracker.Data;

#nullable disable

namespace TftTracker.Migrations
{
    [DbContext(typeof(TftContext))]
    [Migration("20211130033135_AddMatchEntities")]
    partial class AddMatchEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("TftTracker.Data.Entities.Match", b =>
                {
                    b.Property<string>("MatchId")
                        .HasColumnType("TEXT");

                    b.HasKey("MatchId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("TftTracker.Data.Entities.MatchInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("GameDateTime")
                        .HasColumnType("INTEGER");

                    b.Property<float>("GameLength")
                        .HasColumnType("REAL");

                    b.Property<string>("GameVariation")
                        .HasColumnType("TEXT");

                    b.Property<string>("GameVersion")
                        .HasColumnType("TEXT");

                    b.Property<string>("MatchId")
                        .HasColumnType("TEXT");

                    b.Property<int>("QueueId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TftSetNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MatchId")
                        .IsUnique();

                    b.ToTable("MatchInfo");
                });

            modelBuilder.Entity("TftTracker.Data.Entities.MatchMetadata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataVersion")
                        .HasColumnType("TEXT");

                    b.Property<string>("MatchId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MatchId")
                        .IsUnique();

                    b.ToTable("MatchMetadata");
                });

            modelBuilder.Entity("TftTracker.Data.Entities.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GoldLeft")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LastRound")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MatchInfoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MatchMetadataId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Placement")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayersEliminated")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Puuid")
                        .HasColumnType("TEXT");

                    b.Property<string>("SummonerId")
                        .HasColumnType("TEXT");

                    b.Property<float>("TimeEliminated")
                        .HasColumnType("REAL");

                    b.Property<int>("TotalDamageToPlayers")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MatchInfoId");

                    b.HasIndex("MatchMetadataId");

                    b.HasIndex("SummonerId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("TftTracker.Data.Entities.Summoner", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfileIconId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Puuid")
                        .HasColumnType("TEXT");

                    b.Property<long>("RevisionDate")
                        .HasColumnType("INTEGER");

                    b.Property<long>("SummonerLevel")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Summoners");
                });

            modelBuilder.Entity("TftTracker.Data.Entities.MatchInfo", b =>
                {
                    b.HasOne("TftTracker.Data.Entities.Match", "Match")
                        .WithOne("Info")
                        .HasForeignKey("TftTracker.Data.Entities.MatchInfo", "MatchId");

                    b.Navigation("Match");
                });

            modelBuilder.Entity("TftTracker.Data.Entities.MatchMetadata", b =>
                {
                    b.HasOne("TftTracker.Data.Entities.Match", "Match")
                        .WithOne("Metadata")
                        .HasForeignKey("TftTracker.Data.Entities.MatchMetadata", "MatchId");

                    b.Navigation("Match");
                });

            modelBuilder.Entity("TftTracker.Data.Entities.Participant", b =>
                {
                    b.HasOne("TftTracker.Data.Entities.MatchInfo", "MatchInfo")
                        .WithMany("Participants")
                        .HasForeignKey("MatchInfoId");

                    b.HasOne("TftTracker.Data.Entities.MatchMetadata", "MatchMetadata")
                        .WithMany("Participants")
                        .HasForeignKey("MatchMetadataId");

                    b.HasOne("TftTracker.Data.Entities.Summoner", "Summoner")
                        .WithMany("Participations")
                        .HasForeignKey("SummonerId");

                    b.Navigation("MatchInfo");

                    b.Navigation("MatchMetadata");

                    b.Navigation("Summoner");
                });

            modelBuilder.Entity("TftTracker.Data.Entities.Match", b =>
                {
                    b.Navigation("Info");

                    b.Navigation("Metadata");
                });

            modelBuilder.Entity("TftTracker.Data.Entities.MatchInfo", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("TftTracker.Data.Entities.MatchMetadata", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("TftTracker.Data.Entities.Summoner", b =>
                {
                    b.Navigation("Participations");
                });
#pragma warning restore 612, 618
        }
    }
}
