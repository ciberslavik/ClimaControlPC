using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ComponentActivator;
using Castle.MicroKernel.Context;
using ClimaControl.UI.UICore.Dialogs;
using ClimaControl.UI.UICore.Views;
using ClimaControl.UI.Util;

namespace ClimaControl.UI.Impl.Windsor
{
    public class ViewActivator:DefaultComponentActivator
    {
        public ViewActivator(
            ComponentModel model,
            IKernelInternal kernel,
            ComponentInstanceDelegate onCreation, 
            ComponentInstanceDelegate onDestruction) 
            : base(model, kernel, onCreation, onDestruction)
        {
            
        }

        protected override object CreateInstance(CreationContext context, ConstructorCandidate constructor, object[] arguments)
        {
            var component = base.CreateInstance(context, constructor, arguments);
            var assignator = Kernel.Resolve<IViewModelAssignator>();
            assignator.AssignViewModel(component, arguments);
            if (component is IDialogView)
            {
                var mainWindow = Kernel.Resolve<IMainView>();
                assignator.AssignDialogParrent(component, mainWindow);
            }
            return component;
        }
    }
}