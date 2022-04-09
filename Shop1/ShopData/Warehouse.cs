using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData
{
    internal class Warehouse
    {
        public Warehouse()
        {
            Stock = new List<Fruit>();
        }
        public List<Fruit> Stock { get; private set; }
    }
}
