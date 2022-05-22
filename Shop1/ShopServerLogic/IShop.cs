using System;
using System.Collections.Generic;
using ShopServerData;

namespace ShopServerLogic
{
    public interface IShop
    {
        public bool Sell(List<IFruitDTO> fruits);
        public List<IFruitDTO> GetAvailableFruits();
        public event EventHandler<PriceChangeEventArgs> PriceChanged;
    }
}