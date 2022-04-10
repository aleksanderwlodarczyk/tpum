using System.Collections.Generic;
using ShopData;

namespace ShopLogic
{
    public interface IShop
    {
        public bool Sell(List<Fruit> fruits);
    }
}