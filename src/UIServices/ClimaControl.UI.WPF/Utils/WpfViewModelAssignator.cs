using System.Linq;
using System.Windows;
using ClimaControl.UI.UICore.ViewModels;
using ClimaControl.UI.Util;

namespace ClimaControl.UI.WPF.Utils
{
    public class WpfViewModelAssignator:IViewModelAssignator
    {
        public WpfViewModelAssignator()
        {
        }


        public void AssignViewModel(object component, object[] arguments)
        {
            var frameworkElement = component as FrameworkElement;
            if (frameworkElement == null || arguments == null)
            {
                return;
            }

            var vm = arguments.FirstOrDefault(a => a is IViewModel);
            if (vm != null)
            {
                frameworkElement.DataContext = vm;
                //AssignParentView(frameworkElement, vm);
            }
        }

        public void AssignDialogParrent(object component, object parent)
        {
            var dialog = component as Window;
            var pWnd = parent as Window;
            if (dialog != null || pWnd != null)
            {
                dialog.Owner = pWnd;
            }
        }
    }
}