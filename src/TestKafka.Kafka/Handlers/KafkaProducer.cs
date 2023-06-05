using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using TestKafka.Kafka.Builders;
using TestKafka.Kafka.Configs;
using TestKafka.Kafka.Extensions;
using TestKafka.Kafka.Handlers.Interfaces;

namespace TestKafka.Kafka.Handlers
{
    public class KafkaProducer<TKey, TValue> : IDisposable, IKafkaProducer<TKey, TValue> 
        where TValue : class
        where TKey : class
    {
        private readonly ILogger<KafkaProducer<TKey, TValue>> _logger;
        private readonly IProducer<TKey, TValue> _producer;
        private readonly IMessageBuilder<TKey, TValue> _messageBuilder;
        private readonly KafkaProducerConfig _producerOptions;

        public KafkaProducer(ILogger<KafkaProducer<TKey, TValue>> logger,
                             IMessageBuilder<TKey, TValue> messageBuilder,
                             IOptions<KafkaProducerConfig> producerOptions)
        {
            var schemaRegistryConfig = new CachedSchemaRegistryClient(config: new SchemaRegistryConfig() 
            {
                Url = "http://localhost:8081",
                RequestTimeoutMs = 5000,
                BasicAuthUserInfo = String.Empty
            });

            var avroSerializerConfig = new AvroSerializerConfig
            {
                AutoRegisterSchemas = false,
                BufferBytes = 1024
            };

            _logger = logger;
            _messageBuilder = messageBuilder;
            _producerOptions = producerOptions.Value;

            _producer = new ProducerBuilder<TKey, TValue>(CreateProducerConfig()).SetSerializers(schemaRegistryConfig, avroSerializerConfig)
                                                                                 .Build();
        }

        public async Task PublishToTopic(string topic, TKey key, TValue data)
        {
            try
            {
                var messageBuilt = _messageBuilder.BuildMessage(key, data);
                await ProduceAsync(topic, messageBuilt);
            }
            catch(Exception ex)
            {
                _logger.LogError($"PublishToTopic: Error to send a message to topic: {topic} - {ex.Message}");
                throw;
            }
            
        }

        private async Task ProduceAsync(string topic, Message<TKey, TValue> message)
        {
            try
            {
                await _producer.ProduceAsync(topic, message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            _producer.Flush();
            _producer.Dispose();
        }

        private ProducerConfig CreateProducerConfig()
        {
            return new ProducerConfig
            {
                BootstrapServers = _producerOptions.BootstrapServers,
                Acks = Acks.All
            };
        }
    }
}
