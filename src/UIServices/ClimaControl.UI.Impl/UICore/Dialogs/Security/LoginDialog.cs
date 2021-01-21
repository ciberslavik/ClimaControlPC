using ClimaControl.Data;
using ClimaControl.Data.Security;

using ClimaControl.UI.UICore.Dialogs;
using ClimaControl.UI.UICore.Dialogs.Models.Security;
using ClimaControl.UI.UICore.Dialogs.ViewModels.Security;
using ClimaControl.UI.UICore.Dialogs.Views.Security;
using ClimaControl.UI.UICore.ViewModels;

namespace ClimaControl.UI.Impl.UICore.Dialogs.Security
{
    public class LoginDialog:DialogBase,ILoginDialog
    {
        public User User { get; set; }
        public string Title { get; set; }
        public DialogResult Result { get; }

        public LoginDialog(ILoginDialogView view,ILoginDialogViewModel vm) : base(view,vm)
        {
            User = vm.User = new User();
        }
    }
}