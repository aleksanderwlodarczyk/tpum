using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData
{
    internal class Client
    {
        public Client(string name, string surname)
        {
            Name = name;
            Surname = surname;
            ID = Guid.NewGuid();
        }
        public string Name { get; }
        public string Surname { get; }
        public Guid ID { get; }
    }
}
