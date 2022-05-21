using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData
{
    internal class Warehouse : IWarehouse
    {
        public Warehouse()
        {
            Stock = new List<IFruit>();
            observers = new List<IObserver<IFruit>>();

            waitingForStockUpdate = false;
            waitingForSellResponse = false;
            transactionSuccess = false;

            WebSocketClient.OnConnected += Connected;


            ////TODO: connect to server and download products
            //Stock.Add(new Fruit("jabłko zielone", 69f, CountryOfOrigin.Poland, FruitType.Apple));
            //Stock.Add(new Fruit("jabłko czerwone", 96f, CountryOfOrigin.Poland, FruitType.Apple));
            //Stock.Add(new Fruit("Banan bio", 98f, CountryOfOrigin.China, FruitType.Banana));
            //Stock.Add(new Fruit("Banan zwykły", 34f, CountryOfOrigin.India, FruitType.Banana));
            //Stock.Add(new Fruit("Gruszka", 2f, CountryOfOrigin.Poland, FruitType.Pear));
            //Stock.Add(new Fruit("Gruszka zielona", 67f, CountryOfOrigin.Germany, FruitType.Pear));
            //Stock.Add(new Fruit("Gruszka czerwona", 54f, CountryOfOrigin.England, FruitType.Pear));
            //Stock.Add(new Fruit("malinka", 23f, CountryOfOrigin.Poland, FruitType.RaspBerry));
            //Stock.Add(new Fruit("malinka czarna", 169f, CountryOfOrigin.USA, FruitType.RaspBerry));
        }

        public event EventHandler<PriceChangeEventArgs> PriceChanged;
        public List<IFruit> Stock { get; private set; }
        private bool waitingForStockUpdate;
        private bool waitingForSellResponse;
        private bool transactionSuccess;
        private List<IObserver<IFruit>> observers;
        public void RemoveFruits(List<IFruit> fruits)
        {
            foreach (var fruit in fruits)
            {
                RemoveFruit(fruit);
            }
            //fruits.ForEach(x => Stock.Remove(x));
        }

        public void AddFruits(List<IFruit> fruits)
        {
            foreach (var fruit in fruits)
            {
                AddFruit(fruit);
            }
        }

        public void AddFruit(IFruit fruit)
        {
            if (Stock.Find(x => x.ID == fruit.ID) != null)
                return;
            Stock.Add(fruit);
            foreach (var observer in observers)
            {
                observer.OnNext(fruit);
            }
        }

        public void RemoveFruit(IFruit fruit)
        {
            if (Stock.Find(x => x.ID == fruit.ID) == null)
                return;
            Stock.Remove(fruit);

            fruit.Price = -1f;
            fruit.FruitType = FruitType.Deleted;
            fruit.Name = "";
            fruit.Origin = CountryOfOrigin.Deleted;

            foreach (var observer in observers)
            {
                observer.OnNext(fruit);
            }
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

        public async Task SendAsync(string message)
        {
            //testing, console writeline here hehe
            //var json = Serializer.AllFruitsToJson(Stock);
            //await WebSocketClient.CurrentConnection.SendAsync(json);

            //var fruits = Serializer.JsonToManyFruits(json);
            //var fruit = fruits[0];
            //await WebSocketClient.CurrentConnection.SendAsync($"ID: {fruit.ID}, price: {fruit.Price}, name: {fruit.Name}");
            //await WebSocketClient.CurrentConnection.SendAsync($"fruits count: {fruits.Count}");

            waitingForStockUpdate = true;
            await WebSocketClient.CurrentConnection.SendAsync(message);
            //while (waitingForStockUpdate)
            //{

            //}
        }

        public async Task RequestFruitsUpdate()
        {
            await WebSocketClient.CurrentConnection.SendAsync("RequestAll");
        }

        public async Task<bool> TryBuy(List<IFruit> fruits)
        {
            waitingForSellResponse = true;

            string json = Serializer.AllFruitsToJson(fruits);

            await WebSocketClient.CurrentConnection.SendAsync("RequestTransaction" + json);

            while (waitingForSellResponse)
            {

            }

            return transactionSuccess;
        }

        private void ParseMessage(string message)
        {
            if (message.Contains("UpdateAll"))
            {
                string json = message.Substring("UpdateAll".Length);
                List<IFruit> fruits = Serializer.JsonToManyFruits(json);
                foreach (var fruit in fruits)
                {
                    AddFruit(fruit);
                }
                waitingForStockUpdate = false;
            }
            else if (message.Contains("TransactionResult"))
            {
                string resString = message.Substring("TransactionResult".Length);
                transactionSuccess = bool.Parse(resString);
                waitingForSellResponse = false;
                if (!transactionSuccess)
                    RequestFruitsUpdate();
            }
        }

        private async void Connected()
        {
            WebSocketClient.CurrentConnection.onMessage = ParseMessage;
            await RequestFruitsUpdate();
        }

        private void OnPriceChanged(Guid id, float price)
        {
            EventHandler<PriceChangeEventArgs> handler = PriceChanged;
            handler?.Invoke(this, new PriceChangeEventArgs(id, price));
        }

        public IDisposable Subscribe(IObserver<IFruit> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<IFruit>> _observers;
            private IObserver<IFruit> _observer;

            public Unsubscriber(List<IObserver<IFruit>> observers, IObserver<IFruit> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}