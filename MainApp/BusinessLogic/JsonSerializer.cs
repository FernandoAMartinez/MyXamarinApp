using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace BusinessLogic
{
    public class JsonSerializer : ICustomSerializable
    {
        //Define a SerializerSettings for DateTime mapping
        DataContractJsonSerializerSettings serializerSettings =
            new DataContractJsonSerializerSettings()
            { DateTimeFormat = new System.Runtime.Serialization.DateTimeFormat("yyyy-MM-ddTHH:mm:ssZ") };
        public string Serialize<T>(T entity) where T : class, new()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(ms, entity);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
        public T Deserialize<T>(string entity) where T : class, new()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T), serializerSettings);
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(entity)))
            {
                return serializer.ReadObject(ms) as T;
            }
        }
    }
}
