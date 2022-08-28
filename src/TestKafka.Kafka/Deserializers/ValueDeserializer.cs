using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace TestKafka.Kafka.Deserializers
{
    public class ValueDeserializer<TValue> : IDeserializer<TValue>
    {
        public TValue Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            if (isNull) 
            { 
                return default; 
            }

            return JsonConvert.DeserializeObject<TValue>(Encoding.UTF8.GetString(data.ToArray(), 0, data.Length));
        }
    }
}
