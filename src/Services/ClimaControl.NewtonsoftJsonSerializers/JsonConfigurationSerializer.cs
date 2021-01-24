using System.IO;
using System.Text;
using ClimaControl.Data.Configuration;
using Newtonsoft.Json;

namespace ClimaControl.NewtonsoftJsonSerializers
{
    public class JsonConfigurationSerializer:IConfigurationSerializer
    {
        public byte[] Serialize(object item)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            return Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(item,Formatting.Indented));
        }

        public T Deserialize<T>(byte[] dataStream)
        {
            var data = Encoding.ASCII.GetString(dataStream);

            return JsonConvert.DeserializeObject<T>(data);
            
        }
    }
}