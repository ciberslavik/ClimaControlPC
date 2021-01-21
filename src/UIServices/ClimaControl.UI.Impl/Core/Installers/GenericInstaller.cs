using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ClimaControl.Security;
using ClimaControl.UI.Services;

namespace ClimaControl.UI.Impl.Core.Installers
{
    public class GenericInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ISecurityService>().ImplementedBy<ClimaSecurityService>()
                .LifestyleSingleton());
        }
    }
}