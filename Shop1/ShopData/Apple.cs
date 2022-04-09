using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData
{
    internal class Apple : Fruit
    {
        public Apple(string name, float price, CountryOfOrigin origin, AppleType type) : base("Apple", price, origin)
        {
            Type = type;
        }

        public AppleType Type { get; }
    }
}
