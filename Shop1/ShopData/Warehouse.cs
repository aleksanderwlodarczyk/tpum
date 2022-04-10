using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData
{
    internal class Warehouse : IWarehouse
    {
        public Warehouse()
        {
            Stock = new List<Fruit>();
        }

        public List<Fruit> Stock { get; private set; }
        public void RemoveFruits(List<Fruit> fruits)
        {
            fruits.ForEach(x => Stock.Remove(x));
        }

        public void AddFruits(List<Fruit> fruits)
        {
            Stock.AddRange(fruits);
        }

        public List<Fruit> GetFruitsOfType(string name)
        {
            return Stock.FindAll(x => x.Name == name);
        }

        public List<Fruit> GetFruitsOfOrigin(CountryOfOrigin origin)
        {
            return Stock.FindAll(x => x.Origin == origin);
        }
    }
}
