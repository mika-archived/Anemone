﻿using System;
using System.Threading.Tasks;

using Anemone.Views;

using Microsoft.Toolkit.Uwp.Helpers;

namespace Anemone.Services
{
    // For instructions on testing this service see https://github.com/Microsoft/WindowsTemplateStudio/tree/master/docs/features/whats-new-prompt.md
    public class WhatsNewDisplayService : IWhatsNewDisplayService
    {
        private static bool shown = false;

        public async Task ShowIfAppropriateAsync()
        {
            if (SystemInformation.IsAppUpdated && !shown)
            {
                shown = true;
                var dialog = new WhatsNewDialog();
                await dialog.ShowAsync();
            }
        }
    }
}
