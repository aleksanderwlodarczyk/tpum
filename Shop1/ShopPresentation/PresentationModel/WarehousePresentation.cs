﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShopLogic;

namespace TP.ConcurrentProgramming.PresentationModel
{
    public class WarehousePresentation
    {
        private IShop Shop { get; set; }

        public WarehousePresentation(IShop shop)
        {
            Shop = shop;
            Shop.PriceChanged += OnPriceChanged;
        }

        private void OnPriceChanged(object sender, ShopLogic.PriceChangeEventArgs e)
        {
            EventHandler<TP.ConcurrentProgramming.PresentationModel.PriceChangeEventArgs> handler = PriceChanged;
            handler?.Invoke(this, new TP.ConcurrentProgramming.PresentationModel.PriceChangeEventArgs(e.Id, e.Price));
        }

        public async Task SendMessageAsync(string message)
        {
            Shop.SendMessageAsync(message);
        }

        public List<FruitPresentation> GetFruits()
        {
            List<FruitPresentation> fruits = new List<FruitPresentation>();
            foreach (IFruitDTO fruit in Shop.GetAvailableFruits())
            {
                fruits.Add(new FruitPresentation(fruit.Name, fruit.Price, fruit.ID, fruit.Origin, fruit.FruitType));
            }
            return fruits;
        }

        public event EventHandler<TP.ConcurrentProgramming.PresentationModel.PriceChangeEventArgs> PriceChanged;
    }
}
