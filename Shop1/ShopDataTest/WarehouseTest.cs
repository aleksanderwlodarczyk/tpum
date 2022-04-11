using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopData;

namespace ShopDataTest
{
    [TestClass]
    public class WarehouseTest
    {
        private IWarehouse warehouse;
        [TestInitialize]
        public void Initialize()
        {
            warehouse = DataLayer.Create().Warehouse;
            Assert.IsNotNull(warehouse);
            warehouse.Stock.Clear();
            Assert.AreEqual(0, warehouse.Stock.Count);

            List<IFruit> fruitsToAdd = new List<IFruit>();
            fruitsToAdd.Add(new Fruit("jablko czerwone", 50f, CountryOfOrigin.Poland, FruitType.Apple));
            fruitsToAdd.Add(new Fruit("jablko", 50f, CountryOfOrigin.Poland, FruitType.Apple));
            fruitsToAdd.Add(new Fruit("gruszka", 20f, CountryOfOrigin.Germany, FruitType.Pear));
            fruitsToAdd.Add(new Fruit("banan", 16f, CountryOfOrigin.India, FruitType.Banana));
            fruitsToAdd.Add(new Fruit("banan bio", 48f, CountryOfOrigin.India, FruitType.Banana));
            fruitsToAdd.Add(new Fruit("banan chinski", 20f, CountryOfOrigin.China, FruitType.Banana));
            fruitsToAdd.Add(new Fruit("malina", 16f, CountryOfOrigin.India, FruitType.RaspBerry));

            warehouse.AddFruits(fruitsToAdd);
        }

        [TestMethod]
        public void AddFruitsTest()
        {
            List<IFruit> fruitsToAdd = new List<IFruit>();
            fruitsToAdd.Add(new Fruit("jablko", 50f, CountryOfOrigin.Poland, FruitType.Apple));
            fruitsToAdd.Add(new Fruit("gruszka bio", 20f, CountryOfOrigin.Germany, FruitType.Pear));
            fruitsToAdd.Add(new Fruit("banan bio", 16f, CountryOfOrigin.India, FruitType.Banana));
            fruitsToAdd.Add(new Fruit("jablko zielone", 60f, CountryOfOrigin.Poland, FruitType.Apple));

            warehouse.AddFruits(fruitsToAdd);
            Assert.AreEqual(11, warehouse.Stock.Count);
        }
        [TestMethod]
        public void GetFruitTest()
        {
            List<IFruit> apples = warehouse.GetFruitsOfType(FruitType.Apple);

            Assert.IsNotNull(apples);
            Assert.AreEqual(2, apples.Count);
        }
        [TestMethod]
        public void RemoveFruits()
        {
            List<IFruit> bananas = warehouse.GetFruitsOfType(FruitType.Banana);

            Assert.IsNotNull(bananas);
            warehouse.RemoveFruits(bananas);
            Assert.AreEqual(4, warehouse.Stock.Count);
        }
    }
}
