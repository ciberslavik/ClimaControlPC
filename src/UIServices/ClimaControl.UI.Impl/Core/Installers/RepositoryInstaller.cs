using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ClimaControl.Security;
using ClimaControl.Security.Repository.Debug;

namespace ClimaControl.UI.Impl.Core.Installers
{
    public class RepositoryInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ISecurityRepository>().ImplementedBy<DebugSecurityRepository>().LifestyleSingleton());
        }
    }
}