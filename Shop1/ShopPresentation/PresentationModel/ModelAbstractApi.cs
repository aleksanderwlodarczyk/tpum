using ShopLogic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Timers;

namespace TP.ConcurrentProgramming.PresentationModel
{
    public abstract class ModelAbstractApi
    {
        public abstract int Radius { get; }
        public abstract string ColorString { get; }
        public abstract string MainViewVisibility { get; }
        public abstract string BasketViewVisibility { get; } 
        public abstract IWarehousePresentation WarehousePresentation { get; }
        public abstract IBasket Basket { get; }

        public static ModelAbstractApi CreateApi(ILogicLayer logicLayer = default(ILogicLayer))
        {
            return new ModelApi(logicLayer ?? ILogicLayer.Create());
        }
    }

    internal class ModelApi : ModelAbstractApi
    {

        public ModelApi(ILogicLayer logicLayer)
        {
            this.logicLayer = logicLayer;
        }

        public override int Radius => 100;
        public override string ColorString => "White";

        public override string MainViewVisibility => "Visiblie";

        public override string BasketViewVisibility => "Hidden";

        public override IBasket Basket => new Basket(new ObservableCollection<FruitPresentation>(), logicLayer.Shop);

        public override IWarehousePresentation WarehousePresentation => new WarehousePresentation(logicLayer.Shop);

        private ILogicLayer logicLayer;

    }
}