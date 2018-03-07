using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using Anemone.Models;

namespace Anemone.Views
{
    public sealed partial class MasterDetailDetailControl : UserControl
    {
        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder),
                                                                                                       typeof(MasterDetailDetailControl),
                                                                                                       new PropertyMetadata(null,
                                                                                                                            OnMasterMenuItemPropertyChanged));

        public SampleOrder MasterMenuItem
        {
            get => GetValue(MasterMenuItemProperty) as SampleOrder;
            set => SetValue(MasterMenuItemProperty, value);
        }

        public MasterDetailDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MasterDetailDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
