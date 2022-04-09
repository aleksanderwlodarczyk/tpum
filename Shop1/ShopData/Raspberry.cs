using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData
{
    internal class Raspberry : Fruit
    {
        public Raspberry(string name, float price, CountryOfOrigin origin, RaspberryType type) : base(name, price, origin)
        {
            Type = type;
        }

        public RaspberryType Type { get; }
    }
}
