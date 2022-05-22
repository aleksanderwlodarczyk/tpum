using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TP.ConcurrentProgramming.PresentationModel
{
    public interface IWarehousePresentation
    {
        public Task SendMessageAsync(string message);

        public List<FruitPresentation> GetFruits();
        public Task<bool> Connect(Uri uri);
        public Task Disconnect();

        public bool IsConnected();

        public event EventHandler<TP.ConcurrentProgramming.PresentationModel.PriceChangeEventArgs> PriceChanged;
        public event EventHandler<FruitPresentation> FruitChanged;
        public event EventHandler<FruitPresentation> FruitRemoved;
        public event EventHandler<List<FruitPresentation>> TransactionSucceeded;
        public event EventHandler TransactionFailed;
    }
}