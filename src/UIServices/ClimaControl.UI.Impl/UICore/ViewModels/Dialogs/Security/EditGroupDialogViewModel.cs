using ClimaControl.Data.Security;
using ClimaControl.UI.UICore.Dialogs.ViewModels.Security;

namespace ClimaControl.UI.Impl.UICore.ViewModels.Dialogs.Security
{
    public class EditGroupDialogViewModel:IEditGroupDialogViewModel
    {
        public string Title { get; set; }
        public Group Group { get; set; }
    }
}