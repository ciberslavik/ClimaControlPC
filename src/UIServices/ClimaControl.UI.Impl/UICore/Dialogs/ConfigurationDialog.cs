using ClimaControl.Data.Configuration;
using ClimaControl.UI.UICore.Dialogs;
using ClimaControl.UI.UICore.Dialogs.Models;
using ClimaControl.UI.UICore.Dialogs.ViewModels;
using ClimaControl.UI.UICore.Dialogs.Views;

namespace ClimaControl.UI.Impl.UICore.Dialogs
{
    public class ConfigurationDialog : DialogBase, IConfigurationDialog
    {
        public ConfigurationDialog(IConfigurationDialogView view, IConfigurationDialogViewModel vm) : base(view, vm)
        {
        }

        public ConfigItemBase SelectedItem { get; set; }
    }
}