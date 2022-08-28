using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Text;

namespace TestKafka.Kafka.Deserializers
{
    public class KeyDeserializer<TKey> : IDeserializer<TKey>
    {
        public TKey Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            if(isNull)
            {
                return default;
            }

            return JsonConvert.DeserializeObject<TKey>(Encoding.UTF8.GetString(data.ToArray(), 0, data.Length));
        }
    }
}
