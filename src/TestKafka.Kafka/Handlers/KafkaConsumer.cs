using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using TestKafka.Kafka.Configs;
using TestKafka.Kafka.Deserializers;
using TestKafka.Kafka.Handlers.Interfaces;

namespace TestKafka.Kafka.Handlers
{
    public class KafkaConsumer<TKey, TValue> : IDisposable, IKafkaConsumer<TKey, TValue>
        where TKey : class
        where TValue : class
    {
        private readonly ILogger<KafkaConsumer<TKey, TValue>> _logger;
        private readonly IConsumer<TKey, TValue> _consumer;
        private readonly KafkaConsumerConfig _consumerOptions;

        public KafkaConsumer(ILogger<KafkaConsumer<TKey, TValue>> logger,
                             IOptions<KafkaConsumerConfig> consumerOptions)
        {
            _logger = logger;
            _consumerOptions = consumerOptions.Value;

            _consumer = new ConsumerBuilder<TKey, TValue>(CreateConsumerConfig()).SetKeyDeserializer(new KeyDeserializer<TKey>())
                                                                                 .SetValueDeserializer(new ValueDeserializer<TValue>())
                                                                                 .Build();
        }

        public Task<TValue> ConsumeFromTopic(string topic)
        {
            try
            {
                _consumer.Subscribe(topic);

                return Task.Run(() =>
                {
                    var consumerResponse = _consumer.Consume();
                    return consumerResponse.Message.Value;
                });
            }
            catch(ConsumeException ce)
            {
                _logger.LogError($"Error on consume from topic: {topic}: {ce.Message}");
                throw;
            }catch(Exception ex)
            {
                _logger.LogError($"Error on consume from topic: {topic}: {ex.Message}");
                throw;
            }
        }

        public void Dispose()
        {
            _consumer.Unsubscribe();
            _consumer.Close();
            _consumer.Dispose();
        }

        private ConsumerConfig CreateConsumerConfig()
        {
            return new ConsumerConfig
            {
                BootstrapServers = _consumerOptions.BootstrapServers,
                GroupId = _consumerOptions.GroupId,
            };
        }
    }
}
