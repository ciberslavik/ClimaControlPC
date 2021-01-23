namespace ClimaControl.Data.Configuration
{
    public class RootConfigItem:ConfigItemBase
    {
        private string _applicationName;
        private int _versionMinor;
        private int _versionMajor;
        private string _applicationDescription;
        public RootConfigItem() : base()
        {

        }

        public RootConfigItem(string itemName) : base(itemName)
        {

        }

        public string ApplicationName
        {
            get => _applicationName;
            set => _applicationName = value;
        }

        public int VersionMinor
        {
            get => _versionMinor;
            set => _versionMinor = value;
        }

        public int VersionMajor
        {
            get => _versionMajor;
            set => _versionMajor = value;
        }

        public string ApplicationDescription
        {
            get => _applicationDescription;
            set => _applicationDescription = value;
        }
    }
}