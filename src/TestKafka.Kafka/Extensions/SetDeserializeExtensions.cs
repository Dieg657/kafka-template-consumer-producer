using Avro.Specific;
using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using TestKafka.Kafka.Deserializers;

namespace TestKafka.Kafka.Extensions
{
    public static class SetDeserializeExtensions
    {
        public static ConsumerBuilder<TKey, TValue> SetDeserializers<TKey, TValue>(this ConsumerBuilder<TKey, TValue> builder, ISchemaRegistryClient schemaRegistryClient)
            where TValue : class
            where TKey : class
        {
            if (typeof(ISpecificRecord).IsAssignableFrom(typeof(TValue)))
            {
                builder.SetKeyDeserializer(new AvroDeserializer<TKey>(schemaRegistryClient).AsSyncOverAsync())
                       .SetValueDeserializer(new AvroDeserializer<TValue>(schemaRegistryClient).AsSyncOverAsync());
            }else
            {
                builder.SetKeyDeserializer(new KeyDeserializer<TKey>())
                       .SetValueDeserializer(new ValueDeserializer<TValue>());
            }
           
            return builder;
        }
    }
}
