using System;
using System.Collections.Generic;
using ShopData;

namespace ShopLogic
{
    public interface IShop
    {
        public bool Sell(List<FruitDTO> fruits);
        public List<FruitDTO> GetAvailableFruits(bool withPromotion = true);
        public event EventHandler<PriceChangeEventArgs> PriceChanged;
    }
}