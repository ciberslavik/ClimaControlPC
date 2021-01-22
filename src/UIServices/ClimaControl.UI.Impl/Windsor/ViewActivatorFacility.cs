using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;
using ClimaControl.UI.UICore.Dialogs;
using ClimaControl.UI.UICore.Views;

namespace ClimaControl.UI.Impl.Windsor
{
    public class ViewActivatorFacility:AbstractFacility
    {
        


        protected override void Init()
        {
            Kernel.ComponentModelCreated += Kernel_ComponentModelCreated;
        }

        private void Kernel_ComponentModelCreated(ComponentModel model)
        {
            if (typeof(IView).IsAssignableFrom(model.Implementation))
            {
                if (model.CustomComponentActivator == null)
                    model.CustomComponentActivator = typeof(ViewActivator);
            }
            if (typeof(IMainView).IsAssignableFrom(model.Implementation))
            {
                if (model.CustomComponentActivator == null)
                    model.CustomComponentActivator = typeof(ViewActivator);
            }
        }

        
    }
}