using ClimaControl.Data.Security;

namespace ClimaControl.UI.UICore.Dialogs.ViewModels.Security
{
    public interface IEditGroupDialogViewModel:IDialogViewModel
    {
        Group Group { get; set; }
    }
}