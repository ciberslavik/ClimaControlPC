using ClimaControl.UI.UICore.ViewModels;

namespace ClimaControl.UI.UICore.Dialogs.ViewModels
{
    public interface IMessageDialogViewModel:IDialogViewModel
    {
        string Message { get; set; }
    }
}