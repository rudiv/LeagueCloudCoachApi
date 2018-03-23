﻿using LccWebAPI.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LccWebAPI.Repository.StaticData
{
    public interface IItemStaticDataRepository
    {
        IEnumerable<LccItemInformation> GetAllItems();
        LccItemInformation GetItemById(int itemId);
        void InsertItemInformation(LccItemInformation itemInformation);
        void UpdateItemInformation(LccItemInformation itemInformation);
        void Save();
    }
}
