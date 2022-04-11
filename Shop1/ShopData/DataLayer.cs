using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData
{
    public class DataLayer
    {
        public IWarehouse Warehouse { get; private set; }

        public DataLayer()
        {
            Warehouse = new Warehouse();
        }

        public static DataLayer Create()
        {
            return new DataLayer();
        }
    }
}
