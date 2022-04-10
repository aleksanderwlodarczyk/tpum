using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLogic
{
    internal class Basket : IBasket
    {
        private List<FruitDTO> fruits;
        public float CurrentBasketValue { get; private set; }
        public Basket()
        {
            fruits = new List<FruitDTO>();
            CurrentBasketValue = 0f;
        }

        public bool AddFruit(FruitDTO fruit)
        {
            fruits.Add(fruit);
            CurrentBasketValue += fruit.Price;
            return true;
        }

        public bool RemoveFruit(FruitDTO fruit)
        {
            fruits.Remove(fruit);
            CurrentBasketValue -= fruit.Price;
            return true;
        }
    }
}
