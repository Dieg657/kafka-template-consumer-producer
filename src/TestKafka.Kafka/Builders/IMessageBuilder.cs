using Confluent.Kafka;

namespace TestKafka.Kafka.Builders
{
    public interface IMessageBuilder<TKey, TValue>
    {
        Message<TKey, TValue> BuildMessage(TKey key, TValue value);
    }
}
