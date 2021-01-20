using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ClimaControl.Shell.Dialogs;
using ClimaControl.Shell.Impl.ViewModels;
using ClimaControl.Shell.ViewModels;
using ClimaControl.Shell.Views;
using ClimaControl.WPF.Views;

namespace ClimaControl.WPF.Installers
{
    public class MVVMInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromAssemblyContaining<MainView>().BasedOn<IView>().WithServiceFromInterface()
                    .LifestyleTransient(),
                Classes.FromAssemblyContaining<MainViewModel>().BasedOn<IViewModel>().WithServiceFromInterface()
                    .LifestyleTransient(),
                Classes.FromAssemblyContaining<IDialog>().BasedOn<IDialog>().WithServiceFromInterface()
                    .LifestyleTransient());
            

        }
    }
}