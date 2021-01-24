using System;

namespace ClimaControl.Data.Exceptions
{
    public class ConfigurationRepositoryException:Exception
    {
        public ConfigurationRepositoryException()
        {

        }

        public ConfigurationRepositoryException(string message) : base(message)
        {

        }
    }
}