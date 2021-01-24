using System;
using ClimaControl.Data.Configuration;
using ClimaControl.UI.Services.Configuration;
using ClimaControl.UI.Services.Configuration.Model;

namespace ClimaControl.UI.Impl.Core.Services.Configuration
{
    public class ConfigurationService:IConfigurationService
    {
        private readonly IConfigurationRepository _repo;
        
        public ConfigurationService(IConfigurationRepository repo)
        {
            _repo = repo;
            
        }
        public T CreateConfiguration<T>(ConfigItem parent) where T : ConfigItem
        {
            throw new System.NotImplementedException();
        }

        public T CreateConfiguration<T>() where T : ConfigItem
        {
            throw new System.NotImplementedException();
        }

        public ConfigItem GetRootConfig()
        {
            return _repo.GetConfigurationRoot();
        }

        public void UpdateConfig(ConfigItem config)
        {
            throw new System.NotImplementedException();
        }

        public ConfigItem SelectedConfiguration { get; set; }
        public void ReloadConfiguration()
        {
            throw new System.NotImplementedException();
        }
    }
}