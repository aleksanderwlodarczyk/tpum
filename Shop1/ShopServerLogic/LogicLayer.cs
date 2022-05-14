using ShopServerData;

namespace ShopServerLogic
{
    public interface ILogicLayer
    {
        public IShop Shop { get; }
        public static ILogicLayer Create(IDataLayer data = default(IDataLayer))
        {
            return new LogicLayer(data ?? IDataLayer.Create());
        }
    }
    internal class LogicLayer : ILogicLayer
    {
        public IShop Shop { get; }
        private IDataLayer Data { get; }

        public LogicLayer(IDataLayer data)
        {
            Data = data;
            Shop = new Shop(Data.Warehouse);
        }
    }
}