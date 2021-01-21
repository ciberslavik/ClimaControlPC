using ClimaControl.UI.UICore.Dialogs;
using ClimaControl.UI.UICore.Dialogs.Models.Security;
using ClimaControl.UI.UICore.Dialogs.ViewModels.Security;
using ClimaControl.UI.UICore.Dialogs.Views.Security;

namespace ClimaControl.UI.Impl.UICore.Dialogs.Security
{
    public class EditGroupRulesDialog : DialogBase, IEditGroupRulesDialog
    {
        public EditGroupRulesDialog(IEditGroupRulesDialogView view, IEditGroupRulesDialogViewModel vm) : base(view, vm)
        {
        }
    }
}