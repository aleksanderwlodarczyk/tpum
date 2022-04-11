using System;
using System.Collections.Generic;
using System.Text;
using ShopLogic;

namespace TP.ConcurrentProgramming.PresentationModel
{
    public class WarehousePresentation
    {
        private IShop Shop { get; set; }

        public WarehousePresentation(IShop shop)
        {
            Shop = shop;
        }

        public List<FruitDTO> GetFruits()
        {
            return Shop.GetAvailableFruits();
        }

        
    }
}
