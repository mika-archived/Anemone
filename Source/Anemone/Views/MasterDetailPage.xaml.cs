using System;

using Anemone.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Anemone.Views
{
    public sealed partial class MasterDetailPage : Page
    {
        private MasterDetailViewModel ViewModel => DataContext as MasterDetailViewModel;

        public MasterDetailPage()
        {
            InitializeComponent();
        }
    }
}
