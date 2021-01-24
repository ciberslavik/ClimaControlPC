using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ClimaControl.Data.Configuration;
using ClimaControl.FSRepositories;
using ClimaControl.Security;
using ClimaControl.Security.Repository.Debug;
using ClimaControl.UI.Services.Configuration;

namespace ClimaControl.UI.Impl.Core.Installers
{
    public class RepositoryInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<ISecurityRepository>()
                    .ImplementedBy<DebugSecurityRepository>()
                    .LifestyleSingleton(),
                Component
                    .For<IConfigurationRepository>()
                    .ImplementedBy<FSConfigurationRepository>()
                    .LifestyleSingleton());
        }
    }
}