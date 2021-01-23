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
        public T CreateConfiguration<T>(ConfigItemBase parent) where T : ConfigItemBase
        {
            throw new System.NotImplementedException();
        }

        public T CreateConfiguration<T>() where T : ConfigItemBase
        {
            throw new System.NotImplementedException();
        }

        public ConfigItemBase GetRootConfig()
        {
            return _repo.GetConfigurationRoot();
        }

        public void UpdateConfig(ConfigItemBase config)
        {
            throw new System.NotImplementedException();
        }

        public ConfigItemBase SelectedConfiguration { get; set; }
        public void ReloadConfiguration()
        {
            throw new System.NotImplementedException();
        }
    }
}