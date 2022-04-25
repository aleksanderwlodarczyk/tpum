using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.ConcurrentProgramming.PresentationModel
{
    public class PriceChangeEventArgs : EventArgs
    {
        public PriceChangeEventArgs(Guid id, float price)
        {
            Price = price;
            Id = id;
        }
        public Guid Id { get; }
        public float Price { get; }
    }
}
