﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LccWebAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Champions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChampionId = table.Column<int>(nullable: false),
                    ChampionName = table.Column<string>(nullable: true),
                    ImageFull = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matchups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameId = table.Column<long>(nullable: false),
                    MatchDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Runes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Icon = table.Column<string>(nullable: true),
                    Key = table.Column<string>(nullable: true),
                    LongDesc = table.Column<string>(nullable: true),
                    RuneId = table.Column<int>(nullable: false),
                    RuneName = table.Column<string>(nullable: true),
                    RunePathName = table.Column<string>(nullable: true),
                    ShortDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Summoners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<long>(nullable: false),
                    LastUpdatedTime = table.Column<DateTime>(nullable: false),
                    SummonerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summoners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SummonerSpells",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SummonerSpellId = table.Column<int>(nullable: false),
                    SummonerSpellName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummonerSpells", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Db_LccBasicMatchInfoPlayer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChampionId = table.Column<int>(nullable: false),
                    Db_LccBasicMatchInfoId = table.Column<int>(nullable: true),
                    Db_LccBasicMatchInfoId1 = table.Column<int>(nullable: true),
                    Lane = table.Column<string>(nullable: true),
                    PlayerAccountId = table.Column<long>(nullable: false),
                    SummonerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_LccBasicMatchInfoPlayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Db_LccBasicMatchInfoPlayer_Matchups_Db_LccBasicMatchInfoId",
                        column: x => x.Db_LccBasicMatchInfoId,
                        principalTable: "Matchups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_LccBasicMatchInfoPlayer_Matchups_Db_LccBasicMatchInfoId1",
                        column: x => x.Db_LccBasicMatchInfoId1,
                        principalTable: "Matchups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Db_LccBasicMatchInfoPlayer_Db_LccBasicMatchInfoId",
                table: "Db_LccBasicMatchInfoPlayer",
                column: "Db_LccBasicMatchInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_LccBasicMatchInfoPlayer_Db_LccBasicMatchInfoId1",
                table: "Db_LccBasicMatchInfoPlayer",
                column: "Db_LccBasicMatchInfoId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Champions");

            migrationBuilder.DropTable(
                name: "Db_LccBasicMatchInfoPlayer");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Runes");

            migrationBuilder.DropTable(
                name: "Summoners");

            migrationBuilder.DropTable(
                name: "SummonerSpells");

            migrationBuilder.DropTable(
                name: "Matchups");
        }
    }
}