using Windows.UI.Xaml.Controls;

using Anemone.ViewModels;

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
