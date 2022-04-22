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
        public abstract WarehousePresentation WarehousePresentation { get; }
        public abstract Basket Basket { get; }

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

        public override Basket Basket => new Basket(new ObservableCollection<FruitPresentation>(), logicLayer.Shop);

        public override WarehousePresentation WarehousePresentation => new WarehousePresentation(logicLayer.Shop);

        private ILogicLayer logicLayer;
    }
}