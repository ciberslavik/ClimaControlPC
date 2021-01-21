using System.IO;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ClimaControl.UI.Impl.Windsor;
using ClimaControl.UI.UICore.Dialogs;
using ClimaControl.UI.UICore.Themes;
using ClimaControl.UI.UICore.ViewModels;
using ClimaControl.UI.UICore.Views;
using ClimaControl.UI.Util;

namespace ClimaControl.UI.Impl.Core.Installers
{
    public class MVVMInstaller:IWindsorInstaller
    {
        public MVVMInstaller()
        {
        }


        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            string assemblyFile = (
                new System.Uri(Assembly.GetExecutingAssembly().CodeBase)
            ).AbsolutePath;

            string binDirectory = Path.GetDirectoryName(assemblyFile);
            AssemblyFilter asmFilter = new AssemblyFilter(binDirectory,"ClimaControl.UI.*.dll");
            container.Register(
                Classes.FromAssemblyInDirectory(asmFilter)
                    .BasedOn<IViewModelAssignator>()
                    .WithServiceFromInterface()
                    .LifestyleTransient());
                
            container.AddFacility<ViewActivatorFacility>();
            container.Register(
                Classes.FromAssemblyInDirectory(asmFilter)
                    .BasedOn<IView>()
                    .WithServiceFromInterface()
                    .LifestyleTransient(),

                Classes.FromAssemblyInDirectory(asmFilter)
                    .BasedOn<IMainView>()
                    .WithServiceFromInterface()
                    .LifestyleSingleton(),

                Classes.FromAssemblyInDirectory(asmFilter)
                    .BasedOn<IViewModel>()
                    .WithServiceFromInterface()
                    .LifestyleTransient(),

                Classes.FromAssemblyInDirectory(asmFilter)
                    .BasedOn<IDialogViewModel>()
                    .WithServiceFromInterface()
                    .LifestyleTransient(),

                Classes.FromAssemblyInDirectory(asmFilter)
                    .BasedOn<IDialog>()
                    .WithServiceFromInterface()
                    .LifestyleTransient(),

                Classes.FromAssemblyInDirectory(asmFilter)
                    .BasedOn<IDialogView>()
                    .WithServiceFromInterface()
                    .LifestyleTransient());

            container.Register(
                Classes.FromAssemblyInDirectory(asmFilter)
                    .BasedOn<IThemeService>()
                    .WithServiceFromInterface()
                    .LifestyleSingleton(),

                Classes.FromAssemblyInDirectory(asmFilter)
                    .BasedOn<Theme>()
                    .WithServiceBase()
                    .LifestyleSingleton());

        }
    }
}