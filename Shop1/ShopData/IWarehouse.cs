﻿using System;
using System.Collections.Generic;

namespace ShopData
{
    public interface IWarehouse
    {
        public List<IFruit> Stock { get; }
        public void RemoveFruits(List<IFruit> fruits);
        public void AddFruits(List<IFruit> fruits);
        public List<IFruit> GetFruitsOfType(string name);
        public List<IFruit> GetFruitsOfOrigin(CountryOfOrigin origin);
        public List<IFruit> GetFruitsWithIDs(List<Guid> IDs);
    }
}