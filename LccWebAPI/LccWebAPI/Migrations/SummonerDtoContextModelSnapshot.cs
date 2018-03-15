﻿// <auto-generated />
using LccWebAPI.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using RiotSharp.Misc;
using System;

namespace LccWebAPI.Migrations
{
    [DbContext(typeof(SummonerDtoContext))]
    partial class SummonerDtoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LccWebAPI.Models.SummonerDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateLastUpdated");

                    b.Property<long?>("SummonerId");

                    b.HasKey("Id");

                    b.HasIndex("SummonerId");

                    b.ToTable("Summoners");
                });

            modelBuilder.Entity("RiotSharp.SummonerEndpoint.SummonerBase", b =>
                {
                    b.Property<long>("Id");

                    b.Property<long>("AccountId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<int>("Region");

                    b.HasKey("Id");

                    b.ToTable("SummonerBase");

                    b.HasDiscriminator<string>("Discriminator").HasValue("SummonerBase");
                });

            modelBuilder.Entity("RiotSharp.SummonerEndpoint.Summoner", b =>
                {
                    b.HasBaseType("RiotSharp.SummonerEndpoint.SummonerBase");

                    b.Property<long>("Level");

                    b.Property<int>("ProfileIconId");

                    b.Property<DateTime>("RevisionDate");

                    b.ToTable("Summoner");

                    b.HasDiscriminator().HasValue("Summoner");
                });

            modelBuilder.Entity("LccWebAPI.Models.SummonerDto", b =>
                {
                    b.HasOne("RiotSharp.SummonerEndpoint.Summoner", "Summoner")
                        .WithMany()
                        .HasForeignKey("SummonerId");
                });
#pragma warning restore 612, 618
        }
    }
}
