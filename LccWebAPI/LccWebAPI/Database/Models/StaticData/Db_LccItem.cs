﻿using LccWebAPI.Database.Models.Match;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LccWebAPI.Database.Models.StaticData
{
    public class Db_LccItem
    {
        public Db_LccItem() { }

        [Key]
        public int Id { get; set; }

        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public string ImageFull { get; set; }
    }
}
