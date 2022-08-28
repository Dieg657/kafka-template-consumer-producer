using Confluent.Kafka;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace TestKafka.Kafka.Serializers
{
    public class KeySerializer<TKey> : IAsyncSerializer<TKey>
    {
        public async Task<byte[]> SerializeAsync(TKey data, SerializationContext context)
        {
            return await Task.Run(() => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
        }
    }
}
