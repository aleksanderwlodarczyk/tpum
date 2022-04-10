using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData
{
    internal class Fruit : IFruit
    {
        public Fruit(string name, float price, CountryOfOrigin origin, FruitType fruitType)
        {
            Name = name;
            Price = price;
            Origin = origin;
            ID = Guid.NewGuid();
            FruitType = fruitType;
        }

        public string Name { get; }
        public float Price { get; set; }
        public Guid ID { get; }
        public CountryOfOrigin Origin { get; }
        public FruitType FruitType { get; }
    }
}
