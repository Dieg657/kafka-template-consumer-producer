using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using TestKafka.Domain.Messages;
using TestKafka.Domain.Messages.TestKafka;
using TestKafka.Infrastructure.Configs;
using TestKafka.Kafka.Handlers.Interfaces;
using TestKafka.Producer.Builders.Message;
using TestKafka.Producer.Services.Interfaces;

namespace TestKafka.Producer.Services
{
    internal class ProducerService : IProducerService
    {
        private readonly ILogger<ProducerService> _logger;
        private readonly IKafkaProducer<string, MessagePayload<TestKafkaData>> _kafkaTestDataProducer;
        private readonly TestKafkaTopicConfig _topicConfig;

        public ProducerService(ILogger<ProducerService> logger, 
                                     IKafkaProducer<string, MessagePayload<TestKafkaData>> kafkaTestDataProducer,
                                     IOptions<TestKafkaTopicConfig> topicConfig)
        {
            _logger = logger;
            _kafkaTestDataProducer = kafkaTestDataProducer;
            _topicConfig = topicConfig.Value;
        }

        public async Task ProduceMessageToKafka()
        {
            _logger.LogInformation($"Preparing data to send to topic {_topicConfig.TopicName}...");
           
            var messagePayload = MessagePayloadBuilder.BuildMessagePayload(new TestKafkaData(), Guid.NewGuid(), _topicConfig.Domain, _topicConfig.Action);

            await _kafkaTestDataProducer.PublishToTopic(_topicConfig.TopicName, messagePayload.GetHashCode().ToString(), messagePayload);

            _logger.LogInformation($"Data sended!");
        }
    }
}
