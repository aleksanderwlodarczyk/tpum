using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ShopServerDataTest")]
[assembly: InternalsVisibleTo("ShopServerLogicTest")]

namespace ShopServerData
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
        public float Price
        {
            get => price;
            set
            {
                if (value == price)
                    return;
                price = value;
            }
        }
        public Guid ID { get; }
        public CountryOfOrigin Origin { get; }
        public FruitType FruitType { get; }

        private float price;
    }
}
