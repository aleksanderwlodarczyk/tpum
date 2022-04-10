using ShopLogic;

namespace TP.ConcurrentProgramming.PresentationModel
{
    public abstract class ModelAbstractApi
    {
        public abstract int Radius { get; }
        public abstract string ColorString { get; }
        public abstract string MainViewVisibility { get; }
        public abstract string BasketViewVisibility { get; } 
        public abstract WarehousePresentation WarehousePresentation { get; }
        public abstract LogicLayer LogicLayer { get; }

        public static ModelAbstractApi CreateApi()
        {
            return new ModelApi();
        }
    }

    internal class ModelApi : ModelAbstractApi
    {

        public override int Radius => 100;
        public override string ColorString => "White";

        public override string MainViewVisibility => "Visiblie";

        public override string BasketViewVisibility => "Hidden";

        public override WarehousePresentation WarehousePresentation => new WarehousePresentation(LogicLayer.Shop);

        public override LogicLayer LogicLayer => LogicLayer.Create();
    }
}