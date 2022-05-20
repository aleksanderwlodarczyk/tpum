using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopData;

namespace ShopLogic
{
    public interface IShop
    {
        public bool Sell(List<IFruitDTO> fruits);

        public Task SendMessageAsync(string message);

        public List<IFruitDTO> GetAvailableFruits(bool withPromotion = true);
        public event EventHandler<PriceChangeEventArgs> PriceChanged;
    }
}