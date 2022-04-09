using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData
{
    internal class Pear : Fruit
    {
        public Pear(string name, float price, CountryOfOrigin origin, PearType type) : base(name, price, origin)
        {
            Type = type;
        }

        public PearType Type { get; }
    }
}
