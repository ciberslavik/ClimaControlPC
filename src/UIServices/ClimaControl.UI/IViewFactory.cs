using System.Runtime.InteropServices.ComTypes;
using ClimaControl.UI.UICore;
using ClimaControl.UI.UICore.Dialogs;
using ClimaControl.UI.UICore.Views;

namespace ClimaControl.UI
{
    public interface IViewFactory
    {
        T CreateView<T>() where T : IView;
        T CreateDialog<T>() where T : IDialog;
    }
}