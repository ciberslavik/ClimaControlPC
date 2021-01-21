using System;

namespace ClimaControl.Data.Security.Exceptions
{
    public class SecurityException:Exception
    {
        public SecurityException(string message) : base(message)
        {

        }
    }
}