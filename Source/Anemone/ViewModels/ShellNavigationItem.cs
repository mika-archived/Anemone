using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

using Prism.Mvvm;

namespace Anemone.ViewModels
{
    public class ShellNavigationItem : BindableBase
    {
        private readonly IconElement _iconElement;
        private bool _isSelected;

        private SolidColorBrush _selectedForeground;

        private Visibility _selectedVis = Visibility.Collapsed;

        public Visibility SelectedVis
        {
            get => _selectedVis;
            set => SetProperty(ref _selectedVis, value);
        }

        public string Label { get; set; }

        public Symbol Symbol { get; set; }

        public char SymbolAsChar => (char) Symbol;

        public string PageIdentifier { get; set; }

        public IconElement Icon
        {
            get
            {
                var foregroundBinding = new Binding
                {
                    Source = this,
                    Path = new PropertyPath("SelectedForeground"),
                    Mode = BindingMode.OneWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                };

                if (_iconElement != null)
                {
                    BindingOperations.SetBinding(_iconElement, IconElement.ForegroundProperty, foregroundBinding);

                    return _iconElement;
                }

                var fontIcon = new FontIcon {FontSize = 16, Glyph = SymbolAsChar.ToString()};

                BindingOperations.SetBinding(fontIcon, IconElement.ForegroundProperty, foregroundBinding);

                return fontIcon;
            }
        }

        public bool IsSelected
        {
            get => _isSelected;

            set
            {
                SetProperty(ref _isSelected, value);
                SelectedVis = value ? Visibility.Visible : Visibility.Collapsed;
                SelectedForeground = value
                    ? Application.Current.Resources["SystemControlForegroundAccentBrush"] as SolidColorBrush
                    : GetStandardTextColorBrush();
            }
        }

        public SolidColorBrush SelectedForeground
        {
            get => _selectedForeground ?? (_selectedForeground = GetStandardTextColorBrush());

            set => SetProperty(ref _selectedForeground, value);
        }

        public ShellNavigationItem(string name, Symbol symbol, string pageIdentifier)
        {
            Label = name;
            Symbol = symbol;
            PageIdentifier = pageIdentifier;
        }

        public ShellNavigationItem(string name, IconElement icon, string pageIdentifier)
        {
            Label = name;
            _iconElement = icon;
            PageIdentifier = pageIdentifier;
        }

        private SolidColorBrush GetStandardTextColorBrush()
        {
            var brush = Application.Current.Resources["ThemeControlForegroundBaseHighBrush"] as SolidColorBrush;
            return brush;
        }
    }
}
