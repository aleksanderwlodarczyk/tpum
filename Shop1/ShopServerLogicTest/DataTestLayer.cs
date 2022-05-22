using System.Collections.Generic;
using ShopServerData;

namespace ShopServerLogicTest
{
    internal class DataTestLayer : IDataLayer
    {
        public IWarehouse Warehouse { get; set; }

        public DataTestLayer(IWarehouse warehouse)
        {
            Warehouse = warehouse ?? new WarehouseTestExample();
            //Warehouse = new WarehouseTestExample();
            //Warehouse.Stock.Clear();

            //List<IFruit> fruits = new List<IFruit>();
            //fruits.Add(new Fruit("jab³ko zielone", 69f, CountryOfOrigin.Poland, FruitType.Apple));
            //fruits.Add(new Fruit("Banan zwyk³y", 34f, CountryOfOrigin.India, FruitType.Banana));
            //fruits.Add(new Fruit("jab³ko czerwone", 96f, CountryOfOrigin.Poland, FruitType.Apple));
            //fruits.Add(new Fruit("Banan bio", 98f, CountryOfOrigin.China, FruitType.Banana));
            //fruits.Add(new Fruit("Gruszka", 2f, CountryOfOrigin.Poland, FruitType.Pear));
            //fruits.Add(new Fruit("Gruszka zielona", 67f, CountryOfOrigin.Germany, FruitType.Pear));
            //fruits.Add(new Fruit("Gruszka czerwona", 54f, CountryOfOrigin.England, FruitType.Pear));
            //fruits.Add(new Fruit("malinka", 23f, CountryOfOrigin.Poland, FruitType.RaspBerry));
            //fruits.Add(new Fruit("malinka czarna", 169f, CountryOfOrigin.USA, FruitType.RaspBerry));
            //Warehouse.AddFruits(fruits);
        }

    }
}