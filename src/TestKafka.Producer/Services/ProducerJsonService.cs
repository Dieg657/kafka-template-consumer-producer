using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using TestKafka.Domain.Messages;
using TestKafka.Domain.Messages.TestKafka;
using TestKafka.Infrastructure.Configs;
using TestKafka.Kafka.Handlers.Interfaces;
using TestKafka.Producer.Builders.Interfaces;
using TestKafka.Producer.Services.Interfaces;

namespace TestKafka.Producer.Services
{
    public class ProducerJsonService : IProducerJsonService
    {
        private readonly ILogger<ProducerJsonService> _logger;
        private readonly IKafkaProducer<string, MessagePayload<TestKafkaData>> _kafkaTestDataProducer;
        private readonly IPayloadBuilder _builder;
        private readonly TestKafkaTopicConfig _topicConfig;

        public ProducerJsonService(ILogger<ProducerJsonService> logger,
                                     IKafkaProducer<string, MessagePayload<TestKafkaData>> kafkaTestDataProducer,
                                     IPayloadBuilder builder,
                                     IOptions<TestKafkaTopicConfig> topicConfig)
        {
            _logger = logger;
            _kafkaTestDataProducer = kafkaTestDataProducer;
            _builder = builder;
            _topicConfig = topicConfig.Value;
        }

        public async Task ProduceMessage()
        {
            _logger.LogInformation($"Preparing data to send to topic {_topicConfig.TopicName}...");

            var messagePayload = _builder.BuildMessagePayload(new TestKafkaData(), Guid.NewGuid(), _topicConfig.Domain, _topicConfig.Action);

            await _kafkaTestDataProducer.PublishToTopic(_topicConfig.TopicName, messagePayload.GetHashCode().ToString(), messagePayload);

            _logger.LogInformation($"Data sended!");
        }
    }
}
