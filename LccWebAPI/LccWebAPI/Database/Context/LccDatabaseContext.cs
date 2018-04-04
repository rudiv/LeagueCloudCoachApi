﻿using Microsoft.EntityFrameworkCore;

namespace LccWebAPI.Database.Context
{
    public class LccDatabaseContext : DbContext
    {
        public LccDatabaseContext(DbContextOptions<LccDatabaseContext> options) : base(options)
        {
        }
        
        ////Basic information stored for quick match lookup
        //public DbSet<Db_LccBasicMatchInfo> Matchups { get; set; }

        ////Cached matchup information 
        //public DbSet<Db_LccCachedCalculatedMatchupInfo> CalculatedMatchupInformation { get; set; }

        ////Information about summoners to keep track of matchups we've gotten (for now)
        //public DbSet<Db_LccSummoner> Summoners { get; set; }

        ////Static Data
        //public DbSet<Db_LccChampion> Champions { get; set; }
        //public DbSet<Db_LccItem> Items { get; set; }
        //public DbSet<Db_LccRune> Runes { get; set; }
        //public DbSet<Db_LccSummonerSpell> SummonerSpells { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}