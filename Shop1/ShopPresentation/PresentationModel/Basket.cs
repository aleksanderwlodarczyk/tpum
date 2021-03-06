using ShopLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.ConcurrentProgramming.PresentationModel
{
    internal class Basket : IBasket
    {
        public ObservableCollection<FruitPresentation> Fruits { get; set; }
        private IShop Shop { get; set; }

        public Basket(ObservableCollection<FruitPresentation> fruits, IShop shop)
        {
            Fruits = fruits;
            Shop = shop;
        }

        public void Add(FruitPresentation fruit)
        {
            Fruits.Add(fruit);
        }

        public float Sum()
        {
            float res = 0f;
            foreach (FruitPresentation fruit in Fruits)
            {
                res += fruit.Price;
            }

            return res;
        }

        public async Task Buy()
        {
            List<IFruitDTO> shoppingList = new List<IFruitDTO>();

            foreach (FruitPresentation fruitPresentation in Fruits)
            {
                IFruitDTO fruit = Shop.GetAvailableFruits().FirstOrDefault(x => x.ID == fruitPresentation.ID);
                fruit.Price = fruitPresentation.Price;
                shoppingList.Add(fruit);
            }

            Task.Run(async () => await Shop.Sell(shoppingList));

            Fruits.Clear();
        }
    }
}
