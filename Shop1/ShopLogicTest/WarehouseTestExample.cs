using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopData;

namespace ShopLogicTest
{
    internal class WarehouseTestExample : IWarehouse
    {
        public WarehouseTestExample()
        {
            Stock = new List<IFruit>();
        }

        public event EventHandler<PriceChangeEventArgs> PriceChanged;
        public List<IFruit> Stock { get; }

        public void RemoveFruits(List<IFruit> fruits)
        {
            fruits.ForEach(x => Stock.Remove(x));
        }

        public void AddFruits(List<IFruit> fruits)
        {
            Stock.AddRange(fruits);
        }

        public List<IFruit> GetFruitsOfType(FruitType type)
        {
            return Stock.FindAll(x => x.FruitType == type);
        }

        public List<IFruit> GetFruitsOfOrigin(CountryOfOrigin origin)
        {
            return Stock.FindAll(x => x.Origin == origin);
        }

        public List<IFruit> GetFruitsWithIDs(List<Guid> IDs)
        {
            List<IFruit> fruits = new List<IFruit>();
            foreach (Guid guid in IDs)
            {
                List<IFruit> temp = Stock.FindAll(x => x.ID == guid);
                if (temp.Count > 0)
                    fruits.AddRange(temp);
            }

            return fruits;
        }

        public void ChangeFruitPrice(Guid id, float newPrice)
        {
            IFruit fruit = Stock.Find(x => x.ID.Equals(id));

            if (fruit == null)
                return;
            if (Math.Abs(newPrice - fruit.Price) < 0.01f)
                return;
            fruit.Price = newPrice;
            OnPriceChanged(fruit.ID, fruit.Price);
        }

        public Task SendAsync(string message)
        {
            throw new NotImplementedException();
        }

        public Task RequestFruitsUpdate()
        {
            throw new NotImplementedException();
        }

        public Task<bool> TryBuy(List<IFruit> fruits)
        {
            throw new NotImplementedException();
        }

        private void OnPriceChanged(Guid id, float price)
        {
            EventHandler<PriceChangeEventArgs> handler = PriceChanged;
            handler?.Invoke(this, new PriceChangeEventArgs(id, price));
        }

        public IDisposable Subscribe(IObserver<IFruit> observer)
        {
            throw new NotImplementedException();
        }
    }
}