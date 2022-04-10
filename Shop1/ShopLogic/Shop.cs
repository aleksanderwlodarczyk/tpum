using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopData;

namespace ShopLogic
{
    public class Shop
    {
        private IWarehouse warehouse;
        public Shop(IWarehouse warehouse)
        {
            this.warehouse = warehouse;
        }

        public void Buy(List<Fruit> fruits)
        {

        }
    }

    public class Factory
    {
        public Shop GetShop() => new Shop(Warehouse.CreateInstance());
    }

}
