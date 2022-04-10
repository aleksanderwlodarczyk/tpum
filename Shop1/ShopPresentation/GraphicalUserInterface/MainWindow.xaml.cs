using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TP.ConcurrentProgramming.PresentationViewModel;

namespace TP.ConcurrentProgramming.PresentationView
{
    /// <summary>
    /// View implementation
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel _vm = (MainWindowViewModel)DataContext;
        }
    }
}