using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData
{
    public class Warehouse : IWarehouse
    {
        private Warehouse()
        {
            Stock = new List<Fruit>();
        }

        public static Warehouse CreateInstance()
        {
            return new Warehouse();
        }

        public List<Fruit> Stock { get; private set; }
        public void RemoveFruits(List<Fruit> fruits)
        {
            fruits.ForEach(x => Stock.Remove(x));
        }
    }

    public interface IWarehouse
    {
        public void RemoveFruits(List<Fruit> fruits);
    }
}
