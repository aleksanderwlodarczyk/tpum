using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopData;

namespace ShopLogic
{
    internal class Shop : IShop, IObserver<IFruit>
    {
        private IWarehouse warehouse;
        private IDisposable unsubscriber;
        public Shop(IWarehouse warehouse)
        {
            this.warehouse = warehouse;
            warehouse.PriceChanged += OnPriceChanged;
            warehouse.TransactionFailed += OnTransactionFailed;
            warehouse.TransactionSucceeded += OnTransactionSucceeded;
            warehouse.Subscribe(this);
        }

        private void OnTransactionSucceeded(object? sender, List<IFruit> e)
        {
            warehouse.RemoveFruits(e);
            EventHandler<List<IFruitDTO>> handler = TransactionSucceeded;
            List<IFruitDTO> soldFruits = new List<IFruitDTO>();

            foreach (IFruit fruit in e)
            {
                FruitDTO fruitDTO = new FruitDTO();
                fruitDTO.FruitType = fruit.FruitType.ToString();
                fruitDTO.ID = fruit.ID;
                fruitDTO.Name = fruit.Name;
                fruitDTO.Origin = fruit.Origin.ToString();
                fruitDTO.Price = fruit.Price;

                soldFruits.Add(fruitDTO);
            }

            handler?.Invoke(this, soldFruits);
        }

        private void OnTransactionFailed(object? sender, EventArgs e)
        {
            EventHandler handler = TransactionFailed;
            handler?.Invoke(this, e);
        }

        public async Task Sell(List<IFruitDTO> fruitDTOs)
        {
            List<Guid> guids = new List<Guid>();

            foreach (FruitDTO fruitDTO in fruitDTOs)
            {
                guids.Add(fruitDTO.ID);
            }

            List<IFruit> fruits = warehouse.GetFruitsWithIDs(guids);

            foreach (FruitDTO fruitDTO in fruitDTOs)
            {
                IFruit fr = fruits.Find(x => x.ID == fruitDTO.ID);
                if (fr != null)
                    fr.Price = fruitDTO.Price;
            }


            await warehouse.TryBuy(fruits);
        }

        public async Task SendMessageAsync(string message)
        {
            await warehouse.SendAsync(message);
        }

        public List<IFruitDTO> GetAvailableFruits()
        {
            List<IFruitDTO> result = new List<IFruitDTO>();

            foreach (IFruit fruit in warehouse.Stock)
            {
                //float price = fruit.Price;
                //if (fruit.ID.Equals(promotion.Item1))
                //    price *= promotion.Item2;
                var dto = new FruitDTO();
                dto.Price = fruit.Price;
                dto.ID = fruit.ID;
                dto.Name = fruit.Name;
                dto.FruitType = fruit.FruitType.ToString();
                dto.Origin = fruit.Origin.ToString();
                result.Add(dto);
            }

            return result;
        }

        public event EventHandler<PriceChangeEventArgs> PriceChanged;
        public event EventHandler<IFruitDTO> OnFruitChanged;
        public event EventHandler<IFruitDTO> OnFruitRemoved;
        public event EventHandler TransactionFailed;
        public event EventHandler<List<IFruitDTO>> TransactionSucceeded;


        private void OnPriceChanged(object sender, ShopData.PriceChangeEventArgs e)
        {
            EventHandler<PriceChangeEventArgs> handler = PriceChanged;
            handler?.Invoke(this, new ShopLogic.PriceChangeEventArgs(e.Id, e.Price));
        }

        public void OnCompleted()
        {
            this.Unsunscribe();
        }

        public void OnError(Exception error)
        {

        }

        public void OnNext(IFruit value)
        {
            var dto = new FruitDTO();
            dto.Price = value.Price;
            dto.ID = value.ID;
            dto.Name = value.Name;
            dto.FruitType = value.FruitType.ToString();
            dto.Origin = value.Origin.ToString();

            if (value.Price < -0.01f && value.Name == "" && value.FruitType == FruitType.Deleted && value.Origin == CountryOfOrigin.Deleted)
                OnFruitRemoved?.Invoke(this, dto);
            else
                OnFruitChanged?.Invoke(this, dto);
        }

        private void Unsunscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
