using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData
{

    public interface IDataLayer
    {
        public IWarehouse Warehouse { get; set; }

        public static IDataLayer Create()
        {
            return new DataLayer();
        }
    }
    internal class DataLayer : IDataLayer
    {

        internal DataLayer()
        {
            Warehouse = new Warehouse();
        }

        public IWarehouse Warehouse { get; set; }

        public static DataLayer Create()
        {
            return new DataLayer();
        }
    }
}
