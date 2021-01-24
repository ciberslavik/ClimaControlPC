using ClimaControl.Data.Configuration;
using ClimaControl.UI.Services.Configuration.Model;

namespace ClimaControl.UI.UICore.Dialogs.Models
{
    public interface IConfigurationDialog : IDialog
    {
        ConfigItem SelectedItem { get; set; }
    }
}