﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LccWebAPI.Models.DbStaticData
{
    public class SummonerSpell
    {
        // Primary Key
        public int Id { get; set; }

        public int SummonerSpellId { get; set; }
        public string SummonerSpellName { get; set; }
        public string ImageFull { get; set; }
    }
}