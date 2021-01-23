using System.Collections.Generic;
using ClimaControl.Data.Configuration;
using ClimaControl.UI.Services.Configuration.Model;

namespace ClimaControl.UI.Services.Configuration
{
    public interface IConfigurationRepository
    {
        IEnumerable<T> GetConfigsFromType<T>() where T : ConfigItemBase;
        IEnumerable<ConfigItemBase> GetConfigsFromName(string name);
        ConfigItemBase GetConfigurationFromPath(string configPath);
        RootConfigItem GetConfigurationRoot();
        T CreateConfig<T>(ConfigItemBase parent = null) where T : ConfigItemBase, new();
        T CreateConfig<T>(string configurationName, ConfigItemBase parent = null) where T : ConfigItemBase, new();
        T CreateConfig<T>(string configurationName, T instance, ConfigItemBase parent = null) where T : ConfigItemBase, new();
        void UpdateConfig<T>(T config);
    }
}