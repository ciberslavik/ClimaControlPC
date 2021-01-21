using ClimaControl.Data.Security;
using ClimaControl.UI.UICore.Dialogs;
using ClimaControl.UI.UICore.Dialogs.Models.Security;

namespace ClimaControl.UI.Impl.UICore.Dialogs.Security
{
    public class EditGroupDialog:IEditGroupDialog
    {
        public bool? ShowDialog()
        {
            throw new System.NotImplementedException();
        }

        public string Title { get; set; }
        public DialogResult Result { get; }
        public Group Group { get; set; }
    }
}