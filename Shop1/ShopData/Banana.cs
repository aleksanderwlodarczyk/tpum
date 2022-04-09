using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData
{
    internal class Banana : Fruit
    {
        public Banana(string name, float price, CountryOfOrigin origin, BananaType type) : base(name, price, origin)
        {
            Type = type;
        }

        public BananaType Type { get; }
    }
}
