namespace ClimaControl.Data.Configuration
{
    public class RegistryConfigurationItem : ConfigurationItemBase
    {
        public RegistryConfigurationItem()
        {

        }
        public RegistryConfigurationItem(string name,string header="")
        {

        }
        public string FilePath { get; set; }
    }
}