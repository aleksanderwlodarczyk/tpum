using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopData
{
    public interface IWarehouse : IObservable<IFruit>
    {
        public event EventHandler<PriceChangeEventArgs> PriceChanged;
        public event EventHandler TransactionFailed;
        public event EventHandler<List<IFruit>> TransactionSucceeded;
        public List<IFruit> Stock { get; }
        public void RemoveFruits(List<IFruit> fruits);
        public void AddFruits(List<IFruit> fruits);
        public List<IFruit> GetFruitsOfType(FruitType type);
        public List<IFruit> GetFruitsOfOrigin(CountryOfOrigin origin);
        public List<IFruit> GetFruitsWithIDs(List<Guid> IDs);
        public void ChangeFruitPrice(Guid id, float newPrice);

        public Task SendAsync(string message);
        public Task RequestFruitsUpdate();
        Task TryBuy(List<IFruit> fruits);
    }
}