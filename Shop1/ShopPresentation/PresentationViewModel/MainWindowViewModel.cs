using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using TP.ConcurrentProgramming.PresentationModel;
using TP.ConcurrentProgramming.PresentationViewModel.MVVMLight;
using System.Collections.ObjectModel;
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
            fruits = new ObservableCollection<FruitDTO>();
            foreach(FruitDTO fruit in ModelLayer.WarehousePresentation.GetFruits())
            {
                Fruits.Add(fruit);
            }
            basket = ModelLayer.Basket;
            timer = ModelLayer.Timer;
            ButtomClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => ClickHandler());
            BasketButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => BasketButtonClickHandler());
            MainPageButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => MainPagetButtonClickHandler());
            ApplesButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => ApplesButtonClickHandler());
            BananasButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => BananasButtonClickHandler());
            PearsButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => PearsButtonClickHandler());
            RaspberriesButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => RaspberriesButtonClickHandler());

            BuyButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => BuyButtonClickHandler());

            FruitButtonClick = new RelayCommand<Guid>((id) => FruitButtonClickHandler(id));
            timer.Interval = 10000;
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;
        }

        ~MainWindowViewModel()
        {
            timer.Elapsed -= Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            List<FruitDTO> fruitsInShop = ModelLayer.WarehousePresentation.GetFruits();
            Fruits = new ObservableCollection<FruitDTO>();

            foreach (FruitDTO fruit in fruitsInShop)
            {
                Fruits.Add(fruit);
            }
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

        public Basket Basket
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

        public ObservableCollection<FruitDTO> Fruits
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
            foreach (FruitDTO fruit in ModelLayer.WarehousePresentation.GetFruits())
            {
                Fruits.Add(fruit);
            }
        }

        private void BasketButtonClickHandler()
        {
            BasketViewVisibility = "Visible";
            MainViewVisibility = "Hidden";
        }

        private void FruitButtonClickHandler(Guid id)
        {
            foreach (FruitDTO fruit in ModelLayer.WarehousePresentation.GetFruits())
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
            foreach (FruitDTO fruit in ModelLayer.WarehousePresentation.GetFruits())
            {
                if(fruit.FruitType.ToLower().Equals("apple"))
                    Fruits.Add(fruit);
            }
        }

        private void BananasButtonClickHandler()
        {
            Fruits.Clear();
            foreach (FruitDTO fruit in ModelLayer.WarehousePresentation.GetFruits())
            {
                if (fruit.FruitType.ToLower().Equals("banana"))
                    Fruits.Add(fruit);
            }
        }

        private void RaspberriesButtonClickHandler()
        {
            Fruits.Clear();
            foreach (FruitDTO fruit in ModelLayer.WarehousePresentation.GetFruits())
            {
                if (fruit.FruitType.ToLower().Equals("raspberry"))
                    Fruits.Add(fruit);
            }
        }

        private void PearsButtonClickHandler()
        {
            Fruits.Clear();
            foreach (FruitDTO fruit in ModelLayer.WarehousePresentation.GetFruits())
            {
                if (fruit.FruitType.ToLower().Equals("pear"))
                    Fruits.Add(fruit);
            }
        }
        private void MainPagetButtonClickHandler()
        {
            BasketViewVisibility = "Hidden";
            MainViewVisibility = "Visible";
        }

        #endregion public API

        #region private

        private IList<object> b_CirclesCollection;
        private Basket basket;
        private float basketSum;
        private ObservableCollection<FruitDTO> fruits;
        private Timer timer;
        private int b_Radious;
        private string b_colorString;
        private string b_mainViewVisibility;
        private string b_basketViewVisibility;
        private ModelAbstractApi ModelLayer;

        #endregion private

    }
}