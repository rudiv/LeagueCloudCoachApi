﻿// <auto-generated />
using LccWebAPI.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace LccWebAPI.Migrations
{
    [DbContext(typeof(LccDatabaseContext))]
    partial class LccDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LccWebAPI.Database.Models.Match.Db_LccBasicMatchInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("GameId");

                    b.Property<DateTime>("MatchDate");

                    b.HasKey("Id");

                    b.ToTable("Matchups");
                });

            modelBuilder.Entity("LccWebAPI.Database.Models.Match.Db_LccBasicMatchInfoPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChampionId");

                    b.Property<int?>("Db_LccBasicMatchInfoId");

                    b.Property<int?>("Db_LccBasicMatchInfoId1");

                    b.Property<string>("Lane");

                    b.Property<long>("PlayerAccountId");

                    b.Property<string>("SummonerName");

                    b.HasKey("Id");

                    b.HasIndex("Db_LccBasicMatchInfoId");

                    b.HasIndex("Db_LccBasicMatchInfoId1");

                    b.ToTable("Db_LccBasicMatchInfoPlayer");
                });

            modelBuilder.Entity("LccWebAPI.Database.Models.StaticData.Db_LccChampion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChampionId");

                    b.Property<string>("ChampionName");

                    b.HasKey("Id");

                    b.ToTable("Champions");
                });

            modelBuilder.Entity("LccWebAPI.Database.Models.StaticData.Db_LccItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ItemId");

                    b.Property<string>("ItemName");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("LccWebAPI.Database.Models.StaticData.Db_LccRune", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RuneId");

                    b.Property<string>("RuneName");

                    b.HasKey("Id");

                    b.ToTable("Runes");
                });

            modelBuilder.Entity("LccWebAPI.Database.Models.StaticData.Db_LccSummonerSpell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SummonerSpellId");

                    b.Property<string>("SummonerSpellName");

                    b.HasKey("Id");

                    b.ToTable("SummonerSpells");
                });

            modelBuilder.Entity("LccWebAPI.Database.Models.Summoner.Db_LccSummoner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AccountId");

                    b.Property<DateTime>("LastUpdatedTime");

                    b.Property<string>("SummonerName");

                    b.HasKey("Id");

                    b.ToTable("Summoners");
                });

            modelBuilder.Entity("LccWebAPI.Database.Models.Match.Db_LccBasicMatchInfoPlayer", b =>
                {
                    b.HasOne("LccWebAPI.Database.Models.Match.Db_LccBasicMatchInfo")
                        .WithMany("LosingTeamChampions")
                        .HasForeignKey("Db_LccBasicMatchInfoId");

                    b.HasOne("LccWebAPI.Database.Models.Match.Db_LccBasicMatchInfo")
                        .WithMany("WinningTeamChampions")
                        .HasForeignKey("Db_LccBasicMatchInfoId1");
                });
#pragma warning restore 612, 618
        }
    }
}
