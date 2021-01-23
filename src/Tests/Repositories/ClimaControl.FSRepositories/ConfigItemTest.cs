using System.Runtime.Serialization;
using ClimaControl.Data.Configuration;

namespace ClimaControl.FSRepositories
{
    [DataContract]
    public class ConfigItemTest:ConfigItemBase
    {
        private string _testProperty1;
        private string _testProperty2;

        [DataMember]
        public string TestProperty1
        {
            get => _testProperty1;
            set => _testProperty1 = value;
        }

        [DataMember]
        public string TestProperty2
        {
            get => _testProperty2;
            set => _testProperty2 = value;
        }
    }
}