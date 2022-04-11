using ShopLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.ConcurrentProgramming.PresentationModel
{
    public class Basket
    {
        public ObservableCollection<FruitDTO> Fruits { get; set; }
        private IShop Shop { get; set; }

        public Basket(ObservableCollection<FruitDTO> fruits, IShop shop)
        {
            Fruits = fruits;
            Shop = shop;
        }

        public void Add(FruitDTO fruit)
        {
            Fruits.Add(fruit);
        }

        public float Sum()
        {
            float res = 0f;
            foreach (FruitDTO fruit in Fruits)
            {
                res += fruit.Price;
            }

            return res;
        }

        public bool Buy()
        {
            bool res = Shop.Sell(Fruits.ToList());
            if (res)
                Fruits.Clear();

            return res;
        }
    }
}
