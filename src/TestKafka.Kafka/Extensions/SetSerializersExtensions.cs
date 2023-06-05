using Avro.Specific;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using TestKafka.Kafka.Serializers;

namespace TestKafka.Kafka.Extensions
{
    public static class SetSerializersExtensions
    {
        public static ProducerBuilder<TKey, TValue> SetSerializers<TKey, TValue>(this ProducerBuilder<TKey, TValue> builder, ISchemaRegistryClient schemaRegistryClient, AvroSerializerConfig config)
            where TValue : class
            where TKey : class
        {
            if (typeof(ISpecificRecord).IsAssignableFrom(typeof(TValue)))
            {
                builder.SetKeySerializer(new AvroSerializer<TKey>(schemaRegistryClient, config))
                       .SetValueSerializer(new AvroSerializer<TValue>(schemaRegistryClient, config));
            }
            else
            {
                builder.SetKeySerializer(new KeySerializer<TKey>())
                       .SetValueSerializer(new ValueSerializer<TValue>());
            }

            return builder;
        }
    }
}
