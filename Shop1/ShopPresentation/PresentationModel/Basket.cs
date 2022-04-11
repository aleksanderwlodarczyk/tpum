using ShopLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.ConcurrentProgramming.PresentationModel
{
    public class Basket
    {
        public List<FruitDTO> Fruits { get; set; }

        public Basket(List<FruitDTO> fruits)
        {
            Fruits = fruits;
        }

        public void Add(FruitDTO fruit)
        {
            Fruits.Add(fruit);
        }
    }
}
