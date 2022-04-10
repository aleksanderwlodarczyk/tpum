using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using TP.ConcurrentProgramming.PresentationModel;
using TP.ConcurrentProgramming.PresentationViewModel.MVVMLight;

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
            ButtomClick = new RelayCommand(() => ClickHandler());
            BasketButtonClick = new RelayCommand(() => BasketButtonClickHandler());
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
        public Window BasketWindow { get; set; }

        private void ClickHandler()
        {
            // do something usefull
            Radious *= 2;
            ColorString = "Magenta";
            //this.Navigate(new Uri("BasketWindow.xaml", UriKind.Relative));
        }

        private void BasketButtonClickHandler()
        {
            
        }

        #endregion public API

        #region private

        private IList<object> b_CirclesCollection;
        private int b_Radious;
        private string b_colorString;
        private ModelAbstractApi ModelLayer = ModelAbstractApi.CreateApi();

        #endregion private

    }
}