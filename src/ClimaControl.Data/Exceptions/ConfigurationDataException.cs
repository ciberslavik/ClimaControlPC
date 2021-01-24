using System;

namespace ClimaControl.Data.Exceptions
{
    public class ConfigurationDataException:Exception
    {
        public ConfigurationDataException()
        {

        }

        public ConfigurationDataException(string message) : base(message)
        {

        }
    }
}