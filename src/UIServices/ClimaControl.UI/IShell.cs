using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using ClimaControl.UI.UICore.Dialogs;
using ClimaControl.UI.UICore.Themes;
using ClimaControl.UI.UICore.Views;

namespace ClimaControl.UI
{
    public interface IShell
    {
        string Title { get; set; }
        IMainView MainView { get; }

        T CreateDialog<T>() where T:IDialog;
        T CreateView<T>() where T : IView;

        bool Login();
        bool IsLogin { get; }

        IEnumerable<Theme> ShellThemes { get; }
        void SetShellTheme(Theme theme);
    }
}