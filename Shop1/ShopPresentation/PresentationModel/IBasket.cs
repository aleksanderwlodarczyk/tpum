using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace TP.ConcurrentProgramming.PresentationModel
{
    public interface IBasket
    {
        public ObservableCollection<FruitPresentation> Fruits { get; set; }

        public void Add(FruitPresentation fruit);

        public float Sum();

        public Task Buy();
    }
}