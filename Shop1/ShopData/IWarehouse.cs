using System.Collections.Generic;

namespace ShopData
{
    public interface IWarehouse
    {
        public void RemoveFruits(List<Fruit> fruits);
        public void AddFruits(List<Fruit> fruits);
        public List<Fruit> GetFruitsOfType(string name);
        public List<Fruit> GetFruitsOfOrigin(CountryOfOrigin origin);
    }
}