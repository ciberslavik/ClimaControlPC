using System.Runtime.InteropServices.ComTypes;
using ClimaControl.UI.UICore.Views;

namespace ClimaControl.UI
{
    public interface IShell
    {
        string Title { get; set; }
        IMainView MainView { get; }

        T CreateDialog<T>();

        bool Login();
        bool IsLogin { get; }
    }
}