using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Threading.Tasks;
using TestKafka.Consumer.Services.Interfaces;
using TestKafka.Domain.Messages;
using TestKafka.Domain.Messages.TestKafka;
using TestKafka.Infrastructure.Configs;
using TestKafka.Kafka.Handlers.Interfaces;

namespace TestKafka.Consumer.Services
{
    internal class ConsumeJsonService : IConsumeJsonService
    {
        private readonly ILogger<ConsumeJsonService> _logger;
        private readonly IKafkaConsumer<string, MessagePayload<TestKafkaData>> _consumer;
        private readonly TestKafkaTopicConfig _topicConfig;

        public ConsumeJsonService(ILogger<ConsumeJsonService> logger,
                               IKafkaConsumer<string, MessagePayload<TestKafkaData>> consumer,
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

            _logger.LogInformation($"Message retrived: {JsonConvert.SerializeObject(new { message.Meta.InfoData, message.Data })}");
        }
    }
}
