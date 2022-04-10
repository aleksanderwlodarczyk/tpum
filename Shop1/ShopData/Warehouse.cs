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
            Stock = new List<IFruit>();
        }
        public List<IFruit> Stock { get; }

        public void RemoveFruits(List<IFruit> fruits)
        {
            fruits.ForEach(x => Stock.Remove(x));
        }

        public void AddFruits(List<IFruit> fruits)
        {
            Stock.AddRange(fruits);
        }

        public List<IFruit> GetFruitsOfType(string name)
        {
            return Stock.FindAll(x => x.Name == name);
        }

        public List<IFruit> GetFruitsOfOrigin(CountryOfOrigin origin)
        {
            return Stock.FindAll(x => x.Origin == origin);
        }

        public List<IFruit> GetFruitsWithIDs(List<Guid> IDs)
        {
            List<IFruit> fruits = new List<IFruit>();
            foreach (Guid guid in IDs)
            {
                List<IFruit> temp = Stock.FindAll(x => x.ID == guid);
                if (temp.Count > 0)
                    fruits.AddRange(temp);
            }

            return fruits;
        }
    }
}
