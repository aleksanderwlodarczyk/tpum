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
        public abstract Timer Timer { get; }

        public static ModelAbstractApi CreateApi()
        {
            return new ModelApi();
        }
    }

    internal class ModelApi : ModelAbstractApi
    {
        public ModelApi() : this(LogicLayer.Create())
        {

        }

        public ModelApi(LogicLayer logicLayer)
        {
            this.logicLayer = logicLayer;
        }

        public override int Radius => 100;
        public override string ColorString => "White";

        public override string MainViewVisibility => "Visiblie";

        public override string BasketViewVisibility => "Hidden";

        public override Basket Basket => new Basket(new ObservableCollection<FruitDTO>(), logicLayer.Shop);

        public override WarehousePresentation WarehousePresentation => new WarehousePresentation(logicLayer.Shop);

        public override Timer Timer => new Timer();

        private LogicLayer logicLayer;
    }
}