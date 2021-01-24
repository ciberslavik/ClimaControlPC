using ClimaControl.Data.Configuration;

namespace ClimaControl.UI.Services.Configuration.Model
{
    public class TestConfigItem:ConfigItem
    {
        public TestConfigItem():base("Defaault")
        {

        }

        public TestConfigItem(string configName) : base(configName)
        {

        }
    }
}