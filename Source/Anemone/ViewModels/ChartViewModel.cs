using System.Collections.ObjectModel;

using Anemone.Models;
using Anemone.Services;

using Prism.Windows.Mvvm;

namespace Anemone.ViewModels
{
    public class ChartViewModel : ViewModelBase
    {
        private readonly ISampleDataService _sampleDataService;

        public ObservableCollection<DataPoint> Source => _sampleDataService.GetChartSampleData();

        public ChartViewModel(ISampleDataService sampleDataServiceInstance)
        {
            _sampleDataService = sampleDataServiceInstance;
        }
    }
}
