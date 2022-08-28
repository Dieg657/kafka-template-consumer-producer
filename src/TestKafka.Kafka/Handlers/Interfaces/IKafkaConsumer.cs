using System.Threading.Tasks;

namespace TestKafka.Kafka.Handlers.Interfaces
{
    public interface IKafkaConsumer<TKey, TValue>
        where TKey : class
        where TValue : class
    {
        Task<TValue> ConsumeFromTopic(string topic);
    }
}
