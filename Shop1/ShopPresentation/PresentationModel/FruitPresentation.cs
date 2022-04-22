using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TP.ConcurrentProgramming.PresentationModel.Annotations;

namespace TP.ConcurrentProgramming.PresentationModel
{
    public class FruitPresentation : INotifyPropertyChanged
    {
        public FruitPresentation(string name, float price, Guid id, string origin, string fruitType)
        {
            Name = name;
            Price = price;
            ID = id;
            Origin = origin;
            FruitType = fruitType;
        }

        public string Name { get; set; }
        public float Price { get; set; }
        public Guid ID { get; set; }
        public string Origin { get; set; }
        public string FruitType { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
