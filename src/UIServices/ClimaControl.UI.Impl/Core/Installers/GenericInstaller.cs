using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ClimaControl.NewtonsoftJsonSerializers;
using ClimaControl.Security;
using ClimaControl.UI.Impl.Core.Services.Configuration;
using ClimaControl.UI.Services;
using ClimaControl.UI.Services.Configuration;

namespace ClimaControl.UI.Impl.Core.Installers
{
    public class GenericInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));

            container.Register(
                Component
                    .For<IConfigurationSerializer>()
                    .ImplementedBy<JsonConfigurationSerializer>()
                    .LifestyleTransient(),
                Component
                    .For<IConfigurationService>()
                    .ImplementedBy<ConfigurationService>()
                    .LifestyleSingleton(),
                Component
                    .For<ISecurityService>()
                    .ImplementedBy<ClimaSecurityService>()
                    .LifestyleSingleton());
        }
    }
}