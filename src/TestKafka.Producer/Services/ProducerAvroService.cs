using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Test;
using TestKafka.Infrastructure.Configs;
using TestKafka.Kafka.Handlers.Interfaces;
using TestKafka.Producer.Builders.Interfaces;
using TestKafka.Producer.Services.Interfaces;

namespace TestKafka.Producer.Services
{
    public sealed class ProducerAvroService : IProducerAvroService
    {
        private readonly ILogger<ProducerAvroService> _logger;
        private readonly IKafkaProducer<string, TestKafkaAvro> _kafkaTestDataProducer;
        private readonly IPayloadBuilder _builder;
        private readonly TestKafkaTopicConfig _topicConfig;

        public ProducerAvroService(ILogger<ProducerAvroService> logger, 
                                     IKafkaProducer<string, TestKafkaAvro> kafkaTestDataProducer,
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

            var messagePayload = _builder.BuildAvroMessage(Guid.NewGuid(), _topicConfig.Domain, _topicConfig.Action);

            await _kafkaTestDataProducer.PublishToTopic(_topicConfig.TopicName, messagePayload.GetHashCode().ToString(), messagePayload);

            _logger.LogInformation($"Data sended!");
        }
    }
}
