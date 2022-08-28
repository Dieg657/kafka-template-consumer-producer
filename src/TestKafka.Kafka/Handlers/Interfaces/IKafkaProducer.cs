using System.Threading.Tasks;

namespace TestKafka.Kafka.Handlers.Interfaces
{
    public interface IKafkaProducer<TKey, TValue>
        where TValue : class
        where TKey : class
    {
        Task PublishToTopic(string topic, TKey key, TValue data);
    }
}
