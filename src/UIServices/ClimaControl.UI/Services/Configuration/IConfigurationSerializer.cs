using System.IO;

namespace ClimaControl.UI.Services.Configuration
{
    public interface IConfigurationSerializer
    {
        byte[] Serialize(object item);
        T Deserialize<T>(byte[] dataStream);
    }
}