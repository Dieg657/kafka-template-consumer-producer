using Confluent.Kafka;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace TestKafka.Kafka.Serializers
{
    public class ValueSerializer<TValue> : IAsyncSerializer<TValue>
    {
        public Task<byte[]> SerializeAsync(TValue data, SerializationContext context)
        {
            return Task.Run(() => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
        }
    }
}
