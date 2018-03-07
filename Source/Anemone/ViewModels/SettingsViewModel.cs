using System;
using System.Windows.Input;

using Windows.ApplicationModel;
using Windows.UI.Xaml;

using Anemone.Services;

using Microsoft.Services.Store.Engagement;

using Prism.Commands;
using Prism.Windows.Mvvm;

namespace Anemone.ViewModels
{
    // TODO WTS: Add other settings as necessary. For help see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/pages/settings.md
    public class SettingsViewModel : ViewModelBase
    {
        private ElementTheme _elementTheme = ThemeSelectorService.Theme;

        private ICommand _launchFeedbackHubCommand;

        private ICommand _switchThemeCommand;

        private string _versionDescription;
        public Visibility FeedbackLinkVisibility => StoreServicesFeedbackLauncher.IsSupported() ? Visibility.Visible : Visibility.Collapsed;

        public ICommand LaunchFeedbackHubCommand
        {
            get
            {
                if (_launchFeedbackHubCommand == null)
                    _launchFeedbackHubCommand = new DelegateCommand(
                        async () =>
                        {
                            // This launcher is part of the Store Services SDK https://docs.microsoft.com/en-us/windows/uwp/monetize/microsoft-store-services-sdk
                            var launcher = StoreServicesFeedbackLauncher.GetDefault();
                            await launcher.LaunchAsync();
                        });

                return _launchFeedbackHubCommand;
            }
        }

        public ElementTheme ElementTheme
        {
            get => _elementTheme;

            set => SetProperty(ref _elementTheme, value);
        }

        public string VersionDescription
        {
            get => _versionDescription;

            set => SetProperty(ref _versionDescription, value);
        }

        public ICommand SwitchThemeCommand
        {
            get
            {
                if (_switchThemeCommand == null)
                    _switchThemeCommand = new DelegateCommand<object>(
                        async param =>
                        {
                            ElementTheme = (ElementTheme) param;
                            await ThemeSelectorService.SetThemeAsync((ElementTheme) param);
                        });

                return _switchThemeCommand;
            }
        }

        public void Initialize()
        {
            VersionDescription = GetVersionDescription();
        }

        private string GetVersionDescription()
        {
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{package.DisplayName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}
