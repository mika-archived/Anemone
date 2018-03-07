using System;

using Anemone.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Anemone.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
