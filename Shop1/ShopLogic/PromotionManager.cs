using System;
using System.Linq;
using System.Timers;
using ShopData;

namespace ShopLogic
{
    internal class PromotionManager : IPromotionManager
    {
        public PromotionManager(IWarehouse warehouse)
        {
            PromotionTimer = new System.Timers.Timer(10000);
            //PromotionTimer.Elapsed += GetNewPromotion;
            //PromotionTimer.AutoReset = true;
            //PromotionTimer.Enabled = true;
            Warehouse = warehouse;
            Rand = new Random();
            Promotion = 1f;
            FruitOnPromotionID = Guid.Empty;
        }
        private Guid FruitOnPromotionID { get; set; }
        private Timer PromotionTimer { get; }
        private float Promotion { get; set; }
        private IWarehouse Warehouse { get; set; }
        private Random Rand { get; set; }
        private void GetNewPromotion(Object source, ElapsedEventArgs e)
        {
            Promotion = ((float)Rand.NextDouble() * 0.5f) + 0.7f; // 0.7 .. 1.2
            IFruit fruit = Warehouse.Stock[Rand.Next(0, Warehouse.Stock.Count)];
            FruitOnPromotionID = fruit.ID;
            Warehouse.ChangeFruitPrice(FruitOnPromotionID, fruit.Price * Promotion);
        }

        public Tuple<Guid, float> GetCurrentPromotion()
        {
            return new Tuple<Guid, float>(FruitOnPromotionID, Promotion);
        }
    }
}