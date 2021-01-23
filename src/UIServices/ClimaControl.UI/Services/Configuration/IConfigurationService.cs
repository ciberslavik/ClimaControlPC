using ClimaControl.Data.Configuration;
using ClimaControl.UI.Services.Configuration.Model;

namespace ClimaControl.UI.Services.Configuration
{
    public interface IConfigurationService
    {
        T CreateConfiguration<T>() where T : ConfigItemBase;
        ConfigItemBase GetRootConfig();
        void UpdateConfig(ConfigItemBase config);
        ConfigItemBase SelectedConfiguration { get; set; }
        void ReloadConfiguration();
    }
}