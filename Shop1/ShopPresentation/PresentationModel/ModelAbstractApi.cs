namespace TP.ConcurrentProgramming.PresentationModel
{
    public abstract class ModelAbstractApi
    {
        public abstract int Radius { get; }
        public abstract string ColorString { get; }
        public abstract string MainViewVisibility { get; }
        public abstract string BasketViewVisibility { get; }

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
    }
}