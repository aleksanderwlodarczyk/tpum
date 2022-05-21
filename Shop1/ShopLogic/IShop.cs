﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopData;

namespace ShopLogic
{
    public interface IShop
    {
        public Task<bool> Sell(List<IFruitDTO> fruits);

        public Task SendMessageAsync(string message);

        public List<IFruitDTO> GetAvailableFruits();
        public event EventHandler<PriceChangeEventArgs> PriceChanged;
        public event EventHandler<IFruitDTO> OnFruitChanged;
        public event EventHandler<IFruitDTO> OnFruitRemoved;
    }
}