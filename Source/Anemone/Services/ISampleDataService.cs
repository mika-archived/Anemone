using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Anemone.Models;

namespace Anemone.Services
{
    public interface ISampleDataService
    {
        ObservableCollection<DataPoint> GetChartSampleData();

        Task<IEnumerable<SampleOrder>> GetSampleModelDataAsync();
    }
}
