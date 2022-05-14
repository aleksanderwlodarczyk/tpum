using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServerLogic
{
    internal class Basket : IBasket
    {
        private List<IFruitDTO> fruits;
        public float CurrentBasketValue { get; private set; }
        public Basket()
        {
            fruits = new List<IFruitDTO>();
            CurrentBasketValue = 0f;
        }

        public bool AddFruit(IFruitDTO fruit)
        {
            fruits.Add(fruit);
            CurrentBasketValue += fruit.Price;
            return true;
        }

        public bool RemoveFruit(IFruitDTO fruit)
        {
            fruits.Remove(fruit);
            CurrentBasketValue -= fruit.Price;
            return true;
        }
    }
}
