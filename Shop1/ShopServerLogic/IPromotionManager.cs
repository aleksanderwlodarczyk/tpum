using System;

namespace ShopServerLogic
{
    public interface IPromotionManager
    {
        public Tuple<Guid, float> GetCurrentPromotion();
    }
}