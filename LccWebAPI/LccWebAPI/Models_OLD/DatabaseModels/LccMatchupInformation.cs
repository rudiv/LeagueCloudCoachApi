﻿using System;
using System.Collections.Generic;

namespace LccWebAPI.Models.DatabaseModels
{
    //This object is used for quick lookup for matchups
    //You use this to find the GameId of a matchup before requesting it from Riot
    public class LccMatchupInformation
    {
        public LccMatchupInformation() { }
        public LccMatchupInformation(long gameId, DateTime matchDate, List<LccMatchupInformationPlayer> winningTeam, List<LccMatchupInformationPlayer> losingTeam)
        {
            GameId = gameId;
            MatchDate = matchDate;
            WinningTeam = winningTeam;
            LosingTeam = losingTeam;
        }

        public int Id { get; set; }

        public long GameId { get; set; }

        public DateTime MatchDate { get; set; }
        
        public virtual IList<LccMatchupInformationPlayer> WinningTeam { get; set; } = new List<LccMatchupInformationPlayer>();
        
        public virtual IList<LccMatchupInformationPlayer> LosingTeam { get; set; } = new List<LccMatchupInformationPlayer>();
    }
}