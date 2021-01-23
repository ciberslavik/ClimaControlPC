
using ClimaControl.Data;
using ClimaControl.Data.Configuration;
using ClimaControl.UI.Services.Configuration;
using ClimaControl.UI.Services.Configuration.Model;
using ClimaControl.UI.UICore.Dialogs.ViewModels;

namespace ClimaControl.UI.Impl.UICore.ViewModels.Dialogs
{
    public class ConfigurationDialogViewModel :ObservableObject, IConfigurationDialogViewModel
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationDialogViewModel(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }
        public string Title { get; set; }
        public ConfigItemBase SelectedItem { get; set; }
        public ConfigItemBase RootConfiguration
        {
            get => _configurationService.GetRootConfig();
        }
    }
}