using ClimaControl.Data.Configuration;
using ClimaControl.UI.Services.Configuration.Model;

namespace ClimaControl.UI.UICore.Dialogs.ViewModels
{
    public interface IConfigurationDialogViewModel : IDialogViewModel
    {
        ConfigItemBase SelectedItem { get; set; }
        ConfigItemBase RootConfiguration { get; }
    }
}