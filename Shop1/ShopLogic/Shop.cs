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
        private IPromotionManager promotionManager;
        public Shop(IWarehouse warehouse)
        {
            this.warehouse = warehouse;
            promotionManager = new PromotionManager(warehouse);
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

        public List<FruitDTO> GetAvailableFruits(bool withPromotion = true)
        {
            Tuple<Guid, float> promotion = new Tuple<Guid, float>(Guid.Empty, 1f);
            if (withPromotion)
            {
                promotion = promotionManager.GetCurrentPromotion();
            }

            List<FruitDTO> result = new List<FruitDTO>();

            foreach (IFruit fruit in warehouse.Stock)
            {
                float price = fruit.Price;
                if (fruit.ID.Equals(promotion.Item1))
                    price *= promotion.Item2;
                result.Add(new FruitDTO { Price = price, ID = fruit.ID, Name = fruit.Name, FruitType = fruit.FruitType.ToString(), Origin = fruit.Origin.ToString() });
            }

            return result;
        }
    }
}
