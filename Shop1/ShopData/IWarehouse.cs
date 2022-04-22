using System;
using System.Collections.Generic;

namespace ShopData
{
    public interface IWarehouse
    {
        public event EventHandler<PriceChangeEventArgs> PriceChanged; 
        public List<IFruit> Stock { get; }
        public void RemoveFruits(List<IFruit> fruits);
        public void AddFruits(List<IFruit> fruits);
        public List<IFruit> GetFruitsOfType(FruitType type);
        public List<IFruit> GetFruitsOfOrigin(CountryOfOrigin origin);
        public List<IFruit> GetFruitsWithIDs(List<Guid> IDs);
        public void ChangeFruitPrice(Guid id, float newPrice);
    }
}