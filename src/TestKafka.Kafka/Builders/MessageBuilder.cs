using Confluent.Kafka;

namespace TestKafka.Kafka.Builders
{
    public class MessageBuilder<TKey, TValue> : IMessageBuilder<TKey, TValue>
    {
        public virtual Message<TKey, TValue> BuildMessage(TKey key, TValue value)
        {
            return new Message<TKey, TValue>
            { 
                Key = key,
                Value = value,
                Timestamp = new Timestamp(System.DateTime.Now, TimestampType.CreateTime)
            };
        }
    }
}
