using ClimaControl.Data.Security;
using ClimaControl.UI.UICore.ViewModels;

namespace ClimaControl.UI.UICore.Dialogs.ViewModels.Security
{
    public interface ILoginDialogViewModel:IDialogViewModel
    {
        User User { get; set; }
        RelayCommand AcceptDialogCommand { get; }
        string Password { get; set; }

        string ErrorString { get; set; }
    }
}