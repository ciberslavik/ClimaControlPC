using ClimaControl.Data.Security;

namespace ClimaControl.UI.UICore.Dialogs.Models.Security
{
    public interface ILoginDialog:IDialog
    {
        User User { get; set; }
    }
}