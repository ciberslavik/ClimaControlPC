namespace ClimaControl.Data.Configuration
{
    public interface IConfigurationSerializer
    {
        byte[] Serialize(object item);
        T Deserialize<T>(byte[] dataStream);
    }
}