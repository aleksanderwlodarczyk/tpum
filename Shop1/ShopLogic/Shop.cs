using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopData;

namespace ShopLogic
{
    internal class Shop : IShop
    {
        private IWarehouse warehouse;
        public Shop(IWarehouse warehouse)
        {
            this.warehouse = warehouse;
        }

        public bool Sell(List<Fruit> fruits)
        {
            return false;
        }
    }
}
