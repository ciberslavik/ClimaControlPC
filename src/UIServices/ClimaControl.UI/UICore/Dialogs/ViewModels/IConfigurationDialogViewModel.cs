using System.Collections.ObjectModel;
using ClimaControl.Data.Configuration;
using ClimaControl.UI.Services.Configuration.Model;

namespace ClimaControl.UI.UICore.Dialogs.ViewModels
{
    public interface IConfigurationDialogViewModel : IDialogViewModel
    {
        ConfigItem SelectedItem { get; set; }
        ObservableCollection<ConfigItem> Configurations { get; }
    }
}