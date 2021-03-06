using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using TP.ConcurrentProgramming.PresentationModel;
using TP.ConcurrentProgramming.PresentationViewModel.MVVMLight;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ShopLogic;
using Microsoft.Toolkit.Mvvm;
using GalaSoft.MvvmLight.Command;
using System.Timers;

namespace TP.ConcurrentProgramming.PresentationViewModel
{
    public class MainWindowViewModel : ViewModelBase

    {

        #region public API

        public MainWindowViewModel() : this(ModelAbstractApi.CreateApi())
        {
        }

        public MainWindowViewModel(ModelAbstractApi modelAbstractApi)
        {
            ModelLayer = modelAbstractApi;
            Radious = ModelLayer.Radius;
            ColorString = ModelLayer.ColorString;
            MainViewVisibility = ModelLayer.MainViewVisibility;
            BasketViewVisibility = ModelLayer.BasketViewVisibility;
            fruits = new ObservableCollection<FruitPresentation>();
            foreach (FruitPresentation fruit in ModelLayer.WarehousePresentation.GetFruits())
            {
                Fruits.Add(fruit);
            }
            ModelLayer.WarehousePresentation.PriceChanged += OnPriceChanged;
            ModelLayer.WarehousePresentation.FruitChanged += OnFruitChanged;
            ModelLayer.WarehousePresentation.FruitRemoved += OnFruitRemoved;

            ModelLayer.WarehousePresentation.TransactionFailed += OnTransactionFailed;
            ModelLayer.WarehousePresentation.TransactionSucceeded += OnTransactionSucceeded;

            basket = ModelLayer.Basket;
            ButtomClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => ClickHandler());
            BasketButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => BasketButtonClickHandler());
            ConnectButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => ConnectButtonClickHandler());
            MainPageButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => MainPagetButtonClickHandler());
            ApplesButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => ApplesButtonClickHandler());
            BananasButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => BananasButtonClickHandler());
            PearsButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => PearsButtonClickHandler());
            RaspberriesButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => RaspberriesButtonClickHandler());

            BuyButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => BuyButtonClickHandler());

            FruitButtonClick = new RelayCommand<Guid>((id) => FruitButtonClickHandler(id));
        }

        private void OnFruitRemoved(object? sender, FruitPresentation e)
        {
            ObservableCollection<FruitPresentation> newFruits = new ObservableCollection<FruitPresentation>(Fruits);
            FruitPresentation fruit = newFruits.FirstOrDefault(x => x.ID == e.ID);

            if (fruit != null)
            {
                int fruitIndex = newFruits.IndexOf(fruit);
                newFruits.RemoveAt(fruitIndex);
            }

            Fruits = new ObservableCollection<FruitPresentation>(newFruits);
        }

        private void OnTransactionSucceeded(object? sender, List<FruitPresentation> e)
        {
            TransactionStatusText = "Zakup pomyślny";
        }

        private void OnTransactionFailed(object? sender, EventArgs e)
        {
            TransactionStatusText = "Nie udało się zakupić\nowoców";
        }

        private void OnFruitChanged(object? sender, FruitPresentation e)
        {
            ObservableCollection<FruitPresentation> newFruits = new ObservableCollection<FruitPresentation>(Fruits);
            FruitPresentation fruit = newFruits.FirstOrDefault(x => x.ID == e.ID);

            if (fruit != null)
            {
                int fruitIndex = newFruits.IndexOf(fruit);

                if (e.FruitType.ToLower() == "deleted")
                {
                    newFruits.RemoveAt(fruitIndex);
                }
                else
                {
                    newFruits[fruitIndex].Price = e.Price;
                    newFruits[fruitIndex].Name = e.Name;
                    newFruits[fruitIndex].Origin = e.Origin;
                    newFruits[fruitIndex].FruitType = e.FruitType;
                }
            }
            else
            {
                newFruits.Add(e);
            }

            Fruits = new ObservableCollection<FruitPresentation>(newFruits);

        }

        private void OnPriceChanged(object sender, TP.ConcurrentProgramming.PresentationModel.PriceChangeEventArgs e)
        {
            ObservableCollection<FruitPresentation> newFruits = Fruits;
            FruitPresentation fruit = newFruits.FirstOrDefault(x => x.ID == e.Id);
            int fruitIndex = newFruits.IndexOf(fruit);
            newFruits[fruitIndex].Price = e.Price;
            Fruits = new ObservableCollection<FruitPresentation>(newFruits);
        }

        public string ColorString
        {
            get
            {
                return b_colorString;
            }
            set
            {
                if (value.Equals(b_colorString))
                    return;
                b_colorString = value;
                RaisePropertyChanged("ColorString");
            }
        }

        public string ConnectButtonText
        {
            get
            {
                return b_connectButtonText;
            }
            set
            {
                if (value.Equals(b_connectButtonText))
                    return;
                b_connectButtonText = value;
                RaisePropertyChanged("ConnectButtonText");
            }
        }

        public string Log
        {
            get => _log;
            set
            {
                _log = value;
                RaisePropertyChanged("Log");
            }
        }

        private string _log = "Waiting for connection logs...";

        public string MainViewVisibility
        {
            get
            {
                return b_mainViewVisibility;
            }
            set
            {
                if (value.Equals(b_mainViewVisibility))
                    return;
                b_mainViewVisibility = value;
                RaisePropertyChanged("MainViewVisibility");
            }
        }

        public string BasketViewVisibility
        {
            get
            {
                return b_basketViewVisibility;
            }
            set
            {
                if (value.Equals(b_basketViewVisibility))
                    return;
                b_basketViewVisibility = value;
                RaisePropertyChanged("BasketViewVisibility");
            }
        }

        public float BasketSum
        {
            get
            {
                return basketSum;
            }
            set
            {
                if (value.Equals(basketSum))
                    return;
                basketSum = value;
                RaisePropertyChanged("BasketSum");
            }
        }

        public string TransactionStatusText
        {
            get
            {
                return transactionStatusText;
            }
            set
            {
                if (value.Equals(transactionStatusText))
                    return;
                transactionStatusText = value;
                RaisePropertyChanged("TransactionStatusText");
            }
        }

        public IBasket Basket
        {
            get
            {
                return basket;
            }
            set
            {
                if (value.Equals(basket))
                    return;
                basket = value;
                RaisePropertyChanged("Basket");
            }
        }

        public IList<object> CirclesCollection
        {
            get
            {
                return b_CirclesCollection;
            }
            set
            {
                if (value.Equals(b_CirclesCollection))
                    return;
                RaisePropertyChanged("CirclesCollection");
            }
        }

        public ObservableCollection<FruitPresentation> Fruits
        {
            get
            {
                return fruits;
            }
            set
            {
                if (value.Equals(fruits))
                    return;
                fruits = value;
                RaisePropertyChanged("Fruits");
            }
        }

        public int Radious
        {
            get
            {
                return b_Radious;
            }
            set
            {
                if (value.Equals(b_Radious))
                    return;
                b_Radious = value;
                RaisePropertyChanged("Radious");
            }
        }

        public ICommand ButtomClick { get; set; }
        public ICommand BasketButtonClick { get; set; }
        public ICommand ConnectButtonClick { get; set; }
        public ICommand MainPageButtonClick { get; set; }
        public ICommand ApplesButtonClick { get; set; }
        public ICommand BananasButtonClick { get; set; }
        public ICommand RaspberriesButtonClick { get; set; }
        public ICommand PearsButtonClick { get; set; }

        public ICommand FruitButtonClick { get; set; }
        public ICommand BuyButtonClick { get; set; }

        private void ClickHandler()
        {
            // do something usefull
            Radious *= 2;
            ColorString = "Magenta";
            //this.Navigate(new Uri("BasketWindow.xaml", UriKind.Relative));
        }

        private void BuyButtonClickHandler()
        {
            Basket.Buy();
            BasketSum = Basket.Sum();
            Fruits.Clear();
            foreach (FruitPresentation fruit in ModelLayer.WarehousePresentation.GetFruits())
            {
                Fruits.Add(fruit);
            }
        }

        private void BasketButtonClickHandler()
        {
            BasketViewVisibility = "Visible";
            MainViewVisibility = "Hidden";

            ModelLayer.WarehousePresentation.SendMessageAsync("BasketButtonClicked");
        }

        private async Task ConnectButtonClickHandler()
        {
            if (!ModelLayer.WarehousePresentation.IsConnected())
            {
                ConnectButtonText = "łączenie";
                bool result = await ModelLayer.WarehousePresentation.Connect(new Uri("ws://localhost:8081"));
                if (result)
                {
                    ConnectButtonText = "połączono";
                    Fruits.Clear();
                    foreach (FruitPresentation fruit in ModelLayer.WarehousePresentation.GetFruits())
                    {
                        Fruits.Add(fruit);
                    }
                }
            }
            else
            {
                await ModelLayer.WarehousePresentation.Disconnect();
                ConnectButtonText = "rozłączono";
                Fruits.Clear();
            }

        }

        private void FruitButtonClickHandler(Guid id)
        {
            foreach (FruitPresentation fruit in ModelLayer.WarehousePresentation.GetFruits())
            {
                if (fruit.ID.Equals(id))
                {
                    Basket.Add(fruit);
                    BasketSum = Basket.Sum();
                }
            }
        }

        private void ApplesButtonClickHandler()
        {
            Fruits.Clear();
            foreach (FruitPresentation fruit in ModelLayer.WarehousePresentation.GetFruits())
            {
                if (fruit.FruitType.ToLower().Equals("apple"))
                    Fruits.Add(fruit);
            }
        }

        private void BananasButtonClickHandler()
        {
            Fruits.Clear();
            foreach (FruitPresentation fruit in ModelLayer.WarehousePresentation.GetFruits())
            {
                if (fruit.FruitType.ToLower().Equals("banana"))
                    Fruits.Add(fruit);
            }
        }

        private void RaspberriesButtonClickHandler()
        {
            Fruits.Clear();
            foreach (FruitPresentation fruit in ModelLayer.WarehousePresentation.GetFruits())
            {
                if (fruit.FruitType.ToLower().Equals("raspberry"))
                    Fruits.Add(fruit);
            }
        }

        private void PearsButtonClickHandler()
        {
            Fruits.Clear();
            foreach (FruitPresentation fruit in ModelLayer.WarehousePresentation.GetFruits())
            {
                if (fruit.FruitType.ToLower().Equals("pear"))
                    Fruits.Add(fruit);
            }
        }
        private void MainPagetButtonClickHandler()
        {
            BasketViewVisibility = "Hidden";
            MainViewVisibility = "Visible";

            TransactionStatusText = "";

            ModelLayer.WarehousePresentation.SendMessageAsync("echo");
        }

        #endregion public API

        #region private

        private IList<object> b_CirclesCollection;
        private IBasket basket;
        private float basketSum;
        private string transactionStatusText;
        private ObservableCollection<FruitPresentation> fruits;
        private Timer timer;
        private int b_Radious;
        private string b_colorString;
        private string b_connectButtonText;
        private string b_mainViewVisibility;
        private string b_basketViewVisibility;
        private ModelAbstractApi ModelLayer;

        #endregion private

    }
}