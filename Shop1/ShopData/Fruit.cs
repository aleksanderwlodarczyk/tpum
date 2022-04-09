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

        public virtual string Name { get; }
        public virtual float Price { get; }
        public virtual Guid ID { get; }
        public CountryOfOrigin Origin { get; }
    }
}
