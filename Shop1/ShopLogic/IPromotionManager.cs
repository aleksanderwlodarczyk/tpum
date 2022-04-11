using System;

namespace ShopLogic
{
    public interface IPromotionManager
    {
        public Tuple<Guid, float> GetCurrentPromotion();
    }
}