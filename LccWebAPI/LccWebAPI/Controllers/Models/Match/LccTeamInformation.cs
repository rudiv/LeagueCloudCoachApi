﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LccWebAPI.Controllers.Models.Match
{
    public class LccTeamInformation
    {
        public IList<LccPlayerStats> Players { get; set; } = new List<LccPlayerStats>();

        public long TotalKills { get; set; }
        
        public long TotalDeaths { get; set; }

        public long TotalAssists { get; set; }

        public long DragonKills { get;set; }

        public long BaronKills { get; set; }

        public long RiftHeraldKills { get; set; }

        public long InhibitorKills { get; set; }
    }
}
