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
            dataLayer = new DataTestLayer();
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
