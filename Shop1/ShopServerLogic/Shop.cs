using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopServerData;

namespace ShopServerLogic
{
    internal class Shop : IShop
    {
        private IWarehouse warehouse;
        private IPromotionManager promotionManager;
        private readonly object _dataLock = new object();
        public Shop(IWarehouse warehouse)
        {
            this.warehouse = warehouse;
            promotionManager = new PromotionManager(warehouse);
            warehouse.PriceChanged += OnPriceChanged;
        }

        public bool Sell(List<IFruitDTO> fruitDTOs)
        {
            lock (_dataLock)
            {
                List<Guid> guids = new List<Guid>();

                foreach (IFruitDTO fruitDTO in fruitDTOs)
                {
                    guids.Add(fruitDTO.ID);
                }

                List<IFruit> fruits = warehouse.GetFruitsWithIDs(guids);
                if (fruits.Count != fruitDTOs.Count) return false;

                foreach (IFruitDTO fruitDTO in fruitDTOs)
                {
                    var warehouseFruit = fruits.First(x => x.ID == fruitDTO.ID);
                    if (warehouseFruit.Price != fruitDTO.Price) return false;
                }


                warehouse.RemoveFruits(fruits);

                return true;
            }
        }

        public List<IFruitDTO> GetAvailableFruits()
        {

            List<IFruitDTO> result = new List<IFruitDTO>();

            foreach (IFruit fruit in warehouse.Stock)
            {
                result.Add(new FruitDTO { Price = fruit.Price, ID = fruit.ID, Name = fruit.Name, FruitType = (int)fruit.FruitType, Origin = (int)fruit.Origin });
            }

            return result;
        }

        public event EventHandler<PriceChangeEventArgs> PriceChanged;


        private void OnPriceChanged(object sender, ShopServerData.PriceChangeEventArgs e)
        {
            EventHandler<PriceChangeEventArgs> handler = PriceChanged;
            handler?.Invoke(this, new ShopServerLogic.PriceChangeEventArgs(e.Id, e.Price));
        }
    }
}
