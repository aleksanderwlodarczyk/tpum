using ShopData;

namespace ShopLogic
{
    public class LogicLayer
    {
        public IShop Shop { get; private set; }

        private LogicLayer(DataLayer data)
        {
            Shop = new Shop(data.Warehouse);
        }

        public static LogicLayer Create()
        {
            return new LogicLayer(DataLayer.Create());
        }
    }
}