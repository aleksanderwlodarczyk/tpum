using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopData;

namespace ShopLogic
{
    internal class Shop : IShop
    {
        private IWarehouse warehouse;
        private IBasket basket;
        public Shop(IWarehouse warehouse)
        {
            this.warehouse = warehouse;
            basket = new Basket();
        }

        public bool Sell(List<FruitDTO> fruitDTOs)
        {
            List<Guid> guids = new List<Guid>();

            foreach (FruitDTO fruitDTO in fruitDTOs)
            {
                guids.Add(fruitDTO.ID);
            }

            List<IFruit> fruits = warehouse.GetFruitsWithIDs(guids);

            warehouse.RemoveFruits(fruits);

            return true;
        }

        public List<FruitDTO> GetAvailableFruits()
        {
            List<FruitDTO> result = new List<FruitDTO>();

            foreach (IFruit fruit in warehouse.Stock)
            {
                result.Add(new FruitDTO { Price = fruit.Price, ID = fruit.ID, Name = fruit.Name, FruitType = fruit.FruitType.ToString(), Origin = fruit.Origin.ToString() });
            }

            return result;
        }
    }
}
