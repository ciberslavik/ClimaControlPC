namespace ClimaControl.Data.Configuration
{
    public class RegistryConfigurationItem : ConfigurationItemBase
    {
        public RegistryConfigurationItem()
        {

        }
        public RegistryConfigurationItem(string name,string header=""):base(name,header)
        {

        }

        public RegistryConfigurationItem(ConfigurationItemBase item) : base(item)
        {

        }
        public string FilePath { get; set; }
    }
}