﻿using System;
using System.Collections.Generic;
using ShopData;

namespace ShopLogic
{
    public interface IShop
    {
        public bool Sell(List<IFruitDTO> fruits);
        public List<IFruitDTO> GetAvailableFruits(bool withPromotion = true);
        public event EventHandler<PriceChangeEventArgs> PriceChanged;
    }
}