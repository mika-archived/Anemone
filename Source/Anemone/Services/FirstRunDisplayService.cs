using System;
using System.Threading.Tasks;

using Anemone.Views;

using Microsoft.Toolkit.Uwp.Helpers;

namespace Anemone.Services
{
    public class FirstRunDisplayService : IFirstRunDisplayService
    {
        private static bool shown;

        public async Task ShowIfAppropriateAsync()
        {
            if (SystemInformation.IsFirstRun && !shown)
            {
                shown = true;
                var dialog = new FirstRunDialog();
                await dialog.ShowAsync();
            }
        }
    }
}
