using System;
using System.Collections.Generic;
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


            //TODO: connect to server and download products
            Stock.Add(new Fruit("jabłko zielone", 69f, CountryOfOrigin.Poland, FruitType.Apple));
            Stock.Add(new Fruit("jabłko czerwone", 96f, CountryOfOrigin.Poland, FruitType.Apple));
            Stock.Add(new Fruit("Banan bio", 98f, CountryOfOrigin.China, FruitType.Banana));
            Stock.Add(new Fruit("Banan zwykły", 34f, CountryOfOrigin.India, FruitType.Banana));
            Stock.Add(new Fruit("Gruszka", 2f, CountryOfOrigin.Poland, FruitType.Pear));
            Stock.Add(new Fruit("Gruszka zielona", 67f, CountryOfOrigin.Germany, FruitType.Pear));
            Stock.Add(new Fruit("Gruszka czerwona", 54f, CountryOfOrigin.England, FruitType.Pear));
            Stock.Add(new Fruit("malinka", 23f, CountryOfOrigin.Poland, FruitType.RaspBerry));
            Stock.Add(new Fruit("malinka czarna", 169f, CountryOfOrigin.USA, FruitType.RaspBerry));
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

        public async Task SendAsync(string message)
        {
            //testing, console writeline here hehe
            //var json = Serializer.AllFruitsToJson(Stock);
            //await WebSocketClient.CurrentConnection.SendAsync(json);

            //var fruits = Serializer.JsonToManyFruits(json);
            //var fruit = fruits[0];
            //await WebSocketClient.CurrentConnection.SendAsync($"ID: {fruit.ID}, price: {fruit.Price}, name: {fruit.Name}");
            //await WebSocketClient.CurrentConnection.SendAsync($"fruits count: {fruits.Count}");


            await WebSocketClient.CurrentConnection.SendAsync(message);
        }

        private void OnPriceChanged(Guid id, float price)
        {
            EventHandler<PriceChangeEventArgs> handler = PriceChanged;
            handler?.Invoke(this, new PriceChangeEventArgs(id, price));
        }
    }
}