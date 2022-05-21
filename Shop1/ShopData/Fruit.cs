using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ShopDataTest")]
[assembly: InternalsVisibleTo("ShopLogicTest")]

namespace ShopData
{
    internal class Fruit : IFruit
    {
        [JsonConstructor]
        public Fruit(string name, float price, Guid id, CountryOfOrigin origin, FruitType fruitType)
        {
            Name = name;
            Price = price;
            Origin = origin;
            ID = id;
            FruitType = fruitType;
        }
        public Fruit(string name, float price, CountryOfOrigin origin, FruitType fruitType)
        {
            Name = name;
            Price = price;
            Origin = origin;
            ID = Guid.NewGuid();
            FruitType = fruitType;
        }

        public string Name { get; set; }
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
        public CountryOfOrigin Origin { get; set; }
        public FruitType FruitType { get; set; }

        private float price;
    }
}
