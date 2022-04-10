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

            Stock.Add(new Fruit("jabłko zielone", 69f, CountryOfOrigin.Poland, FruitType.Apple));
            Stock.Add(new Fruit("jabłko czerwone", 96f, CountryOfOrigin.Poland, FruitType.Apple));
            Stock.Add(new Fruit("Banan bio", 98f, CountryOfOrigin.China, FruitType.Banana));
            Stock.Add(new Fruit("Banan zwykły", 34f, CountryOfOrigin.India, FruitType.Banana));
            Stock.Add(new Fruit("Gruszka", 2f, CountryOfOrigin.Poland, FruitType.Pear));
            Stock.Add(new Fruit("Gruszka zielona", 67f, CountryOfOrigin.Germany, FruitType.Pear));
            Stock.Add(new Fruit("Gruszka czerwona", 54f, CountryOfOrigin.England, FruitType.Pear));
            Stock.Add(new Fruit("malinka", 23f, CountryOfOrigin.Poland, FruitType.RaspBerry));
            Stock.Add(new Fruit("malinka czarna", 169f, CountryOfOrigin.USA, FruitType.RaspBerry));
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
