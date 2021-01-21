using ClimaControl.UI.UICore.ViewModels;

namespace ClimaControl.UI.UICore.Dialogs.ViewModels
{
    public interface IMessageDialogViewModel:IViewModel
    {
        string Title { get; set; }
        string Message { get; set; }
    }
}