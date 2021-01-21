using ClimaControl.Data.Security;

namespace ClimaControl.UI.UICore.Dialogs.Models.Security
{
    public interface IEditGroupDialog:IDialog
    {
        Group Group { get; set; }
    }
}