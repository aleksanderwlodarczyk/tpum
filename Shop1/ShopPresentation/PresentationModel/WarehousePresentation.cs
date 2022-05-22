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
            Shop.OnFruitChanged += OnFruitChanged;
            Shop.TransactionFailed += OnTransactionFailed;
            Shop.TransactionSucceeded += OnTransactionSucceeded;
        }

        private void OnTransactionSucceeded(object? sender, List<IFruitDTO> e)
        {
            EventHandler<List<FruitPresentation>> handler = TransactionSucceeded;
            List<FruitPresentation> soldFruitPresentations = new List<FruitPresentation>();
            foreach (IFruitDTO fruitDto in e)
            {
                FruitPresentation fruitPresentation = new FruitPresentation(fruitDto.Name, fruitDto.Price, fruitDto.ID,
                    fruitDto.Origin, fruitDto.FruitType);
                soldFruitPresentations.Add(fruitPresentation);
            }

            handler?.Invoke(this, soldFruitPresentations);
        }

        private void OnTransactionFailed(object? sender, EventArgs e)
        {
            EventHandler handler = TransactionFailed;
            handler?.Invoke(this, e);
        }

        private void OnFruitChanged(object? sender, IFruitDTO e)
        {
            EventHandler<FruitPresentation> handler = FruitChanged;
            FruitPresentation fruit = new FruitPresentation(e.Name, e.Price, e.ID, e.Origin, e.FruitType);
            handler?.Invoke(this, fruit);
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
        public event EventHandler<FruitPresentation> FruitChanged;
        public event EventHandler<List<FruitPresentation>> TransactionSucceeded;
        public event EventHandler TransactionFailed;
    }
}
