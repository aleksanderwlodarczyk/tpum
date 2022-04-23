using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopData;
using ShopLogic;

namespace ShopLogicTest
{
    [TestClass]
    public class ShopTest
    {
        private IDataLayer dataLayer;
        private IShop shop;

        [TestInitialize]
        public void Initialize()
        {
            //dataLayer = IDataLayer.Create();
            WarehouseTestExample warehouse = new WarehouseTestExample();

            List<IFruit> fruits = new List<IFruit>();
            fruits.Add(new Fruit("jab³ko zielone", 69f, CountryOfOrigin.Poland, FruitType.Apple));
            fruits.Add(new Fruit("Banan zwyk³y", 34f, CountryOfOrigin.India, FruitType.Banana));
            fruits.Add(new Fruit("jab³ko czerwone", 96f, CountryOfOrigin.Poland, FruitType.Apple));
            fruits.Add(new Fruit("Banan bio", 98f, CountryOfOrigin.China, FruitType.Banana));
            fruits.Add(new Fruit("Gruszka", 2f, CountryOfOrigin.Poland, FruitType.Pear));
            fruits.Add(new Fruit("Gruszka zielona", 67f, CountryOfOrigin.Germany, FruitType.Pear));
            fruits.Add(new Fruit("Gruszka czerwona", 54f, CountryOfOrigin.England, FruitType.Pear));
            fruits.Add(new Fruit("malinka", 23f, CountryOfOrigin.Poland, FruitType.RaspBerry));
            fruits.Add(new Fruit("malinka czarna", 169f, CountryOfOrigin.USA, FruitType.RaspBerry));
            warehouse.AddFruits(fruits);

            dataLayer = new DataTestLayer(warehouse);
            Assert.IsNotNull(dataLayer);


            shop = ILogicLayer.Create(dataLayer).Shop;

        }

        [TestMethod]
        public void GetAvailableProducts()
        {
            List<FruitDTO> fruits = shop.GetAvailableFruits();
            Assert.IsNotNull(fruits);
            Assert.AreEqual(9, fruits.Count);
        }

        [TestMethod]
        public void SellAllTest()
        {
            List<FruitDTO> fruits = shop.GetAvailableFruits();
            Assert.IsNotNull(fruits);
            Assert.AreEqual(9, fruits.Count);

            shop.Sell(fruits);

            List<FruitDTO> remainingFruits = shop.GetAvailableFruits();
            Assert.IsNotNull(remainingFruits);
            Assert.AreEqual(0, remainingFruits.Count);
        }

        [TestMethod]
        public void SellTest()
        {
            List<FruitDTO> fruits = shop.GetAvailableFruits();
            Assert.IsNotNull(fruits);
            Assert.AreEqual(9, fruits.Count);

            List<FruitDTO> fruitsFromPoland = fruits.FindAll(x => x.Origin.ToLower().Equals("poland"));
            fruitsFromPoland.ForEach(x => fruits.Remove(x));
            Assert.AreEqual(5, fruits.Count);
            Assert.AreEqual(4, fruitsFromPoland.Count);

            shop.Sell(fruitsFromPoland);

            List<FruitDTO> remainingFruits = shop.GetAvailableFruits();
            Assert.IsNotNull(remainingFruits);
            Assert.AreEqual(5, remainingFruits.Count);

            List<FruitDTO> fruitsInShopFromPoland = remainingFruits.FindAll(x => x.Origin.ToLower().Equals("poland"));
            Assert.IsNotNull(fruitsInShopFromPoland);
            Assert.AreEqual(0, fruitsInShopFromPoland.Count);
        }
    }
}
