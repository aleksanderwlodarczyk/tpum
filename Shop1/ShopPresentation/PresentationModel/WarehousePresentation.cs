using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShopLogic;

namespace TP.ConcurrentProgramming.PresentationModel
{
    internal class WarehousePresentation : IWarehousePresentation
    {
        private IShop Shop { get; set; }
        private IConnectionService _connectionService;

        public WarehousePresentation(IShop shop)
        {
            Shop = shop;
            Shop.PriceChanged += OnPriceChanged;
            Shop.OnFruitChanged += OnFruitChanged;
            Shop.TransactionFailed += OnTransactionFailed;
            Shop.OnFruitRemoved += OnFruitRemoved;
            Shop.TransactionSucceeded += OnTransactionSucceeded;
            _connectionService = ServiceFactory.CreateConnectionService;
            _connectionService.ConnectionLogger += ConnectionLogger;
        }

        private void ConnectionLogger(string obj)
        {
            Console.WriteLine(obj);
        }

        private void OnFruitRemoved(object? sender, IFruitDTO e)
        {
            EventHandler<FruitPresentation> handler = FruitRemoved;
            FruitPresentation fruit = new FruitPresentation(e.Name, e.Price, e.ID, e.Origin, e.FruitType);
            handler?.Invoke(this, fruit);
        }

        private void OnTransactionSucceeded(object? sender, List<IFruitDTO> e)
        {
            EventHandler<List<FruitPresentation>> handler = TransactionSucceeded;
            List<FruitPresentation> soldFruitPresentations = new List<FruitPresentation>();
            foreach (IFruitDTO fruitDto in e)
            {
                FruitPresentation fruitPresentation = new FruitPresentation(fruitDto.Name, fruitDto.Price, fruitDto.ID,
                    fruitDto.Origin, fruitDto.FruitType);
                soldFruitPresentations.Add(fruitPresentation);
            }

            handler?.Invoke(this, soldFruitPresentations);
        }

        private void OnTransactionFailed(object? sender, EventArgs e)
        {
            EventHandler handler = TransactionFailed;
            handler?.Invoke(this, e);
        }

        private void OnFruitChanged(object? sender, IFruitDTO e)
        {
            EventHandler<FruitPresentation> handler = FruitChanged;
            FruitPresentation fruit = new FruitPresentation(e.Name, e.Price, e.ID, e.Origin, e.FruitType);
            handler?.Invoke(this, fruit);
        }

        private void OnPriceChanged(object sender, ShopLogic.PriceChangeEventArgs e)
        {
            EventHandler<TP.ConcurrentProgramming.PresentationModel.PriceChangeEventArgs> handler = PriceChanged;
            handler?.Invoke(this, new TP.ConcurrentProgramming.PresentationModel.PriceChangeEventArgs(e.Id, e.Price));
        }


        public async Task SendMessageAsync(string message)
        {
            Shop.SendMessageAsync(message);
        }

        public List<FruitPresentation> GetFruits()
        {
            List<FruitPresentation> fruits = new List<FruitPresentation>();
            foreach (IFruitDTO fruit in Shop.GetAvailableFruits())
            {
                fruits.Add(new FruitPresentation(fruit.Name, fruit.Price, fruit.ID, fruit.Origin, fruit.FruitType));
            }
            return fruits;
        }

        public Task<bool> Connect(Uri uri)
        {
            return _connectionService.Connect(uri);
        }

        public async Task Disconnect()
        {
            await _connectionService.Disconnect();
        }

        public bool IsConnected()
        {
            return _connectionService.Connected;
        }

        public event EventHandler<TP.ConcurrentProgramming.PresentationModel.PriceChangeEventArgs> PriceChanged;
        public event EventHandler<FruitPresentation> FruitChanged;
        public event EventHandler<FruitPresentation> FruitRemoved;
        public event EventHandler<List<FruitPresentation>> TransactionSucceeded;
        public event EventHandler TransactionFailed;
    }
}
