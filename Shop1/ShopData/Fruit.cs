using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData
{
    internal abstract class Fruit
    {
        public Fruit(string name, float price, CountryOfOrigin origin)
        {
            Name = name;
            Price = price;
            Origin = origin;
            ID = Guid.NewGuid();
        }

        public  string Name { get; }
        public  float Price { get; set; }
        public  Guid ID { get; }
        public CountryOfOrigin Origin { get; }
    }
}
