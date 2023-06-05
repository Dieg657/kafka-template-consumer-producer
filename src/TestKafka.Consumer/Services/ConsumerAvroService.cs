using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Test;
using TestKafka.Consumer.Services.Interfaces;
using TestKafka.Domain.Messages;
using TestKafka.Domain.Messages.TestKafka;
using TestKafka.Infrastructure.Configs;
using TestKafka.Kafka.Handlers.Interfaces;

namespace TestKafka.Consumer.Services
{
    internal class ConsumerAvroService : IConsumerAvroService
    {
        private readonly ILogger<ConsumerAvroService> _logger;
        private readonly IKafkaConsumer<string, TestKafkaAvro> _consumer;
        private readonly TestKafkaTopicConfig _topicConfig;

        public ConsumerAvroService(ILogger<ConsumerAvroService> logger,
                               IKafkaConsumer<string, TestKafkaAvro> consumer,
                               IOptions<TestKafkaTopicConfig> topicConfig)
        {
            _logger = logger;
            _consumer = consumer;
            _topicConfig = topicConfig.Value;
        }

        public async Task ConsumeMessage()
        {
            _logger.LogInformation($"Consuming message from topic: {_topicConfig.TopicName}...");

            var message = await _consumer.ConsumeFromTopic(_topicConfig.TopicName);

            _logger.LogInformation($"Message retrived: {JsonConvert.SerializeObject(new {message.meta.infoData, message.data.publishedTime})}");
        }
    }
}
