using Confluent.Kafka;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Test;
using TestKafka.Infrastructure.Configs;
using TestKafka.Kafka.Handlers.Interfaces;
using TestKafka.Producer.Builders.Interfaces;
using TestKafka.Producer.Services;

namespace TestKaka.Producer.Tests.Services
{
    internal class ProducerAvroServiceTests
    {
        private Mock<ILogger<ProducerAvroService>> _logger;
        private Mock<IKafkaProducer<string, TestKafkaAvro>> _kafkaTestDataProducer;
        private Mock<IPayloadBuilder> _builder;
        private IOptions<TestKafkaTopicConfig> _topicConfig;
        private ProducerAvroService _service;

        [SetUp]
        public void Setup() 
        {
            _logger = new();
            _kafkaTestDataProducer = new();
            _builder = new();
            _topicConfig = CreateOptions();

            _service = new ProducerAvroService(_logger.Object, _kafkaTestDataProducer.Object, _builder.Object, _topicConfig);
        }

        [Test]
        public void ProducerAvroService_WhenPublish_SuccessAsync()
        {
            // Arrage
            var messageAvro = new TestKafkaAvro()
            {
                data = new data() { publishedTime = DateTime.Now.ToString() },
                meta = new meta
                {
                    infoData = new infoData
                    {
                        action = _topicConfig.Value.Action,
                        correlationId = Guid.NewGuid().ToString(),
                        domain = _topicConfig.Value.Domain,
                        id = Guid.NewGuid().ToString(),
                        timestamp = (int)DateTimeOffset.Now.ToUnixTimeSeconds()
                    }
                }
            };

            _builder.Setup(x => x.BuildAvroMessage(It.IsAny<Guid>(), _topicConfig.Value.Domain, _topicConfig.Value.Action)).Returns(messageAvro);
            _kafkaTestDataProducer.Setup(x => x.PublishToTopic(_topicConfig.Value.TopicName, messageAvro.GetHashCode().ToString(), messageAvro));

            // Act
            Func<Task?> act = async () => await _service.ProduceMessage();

            // Assert
            act.Should().NotThrowAsync();
            _kafkaTestDataProducer.Verify(x => x.PublishToTopic(_topicConfig.Value.TopicName, messageAvro.GetHashCode().ToString(), messageAvro), Times.Once);
            //_logger.Verify(x => x.LogInformation(It.IsAny<string>()), Times.Once);
            //_logger.Verify(x => x.LogInformation(It.IsAny<string>()), Times.Once);
        }


        private IOptions<TestKafkaTopicConfig> CreateOptions()
        {
            return Options.Create(new TestKafkaTopicConfig
            {
                Action = "POST",
                Domain = "TestKafka.Producer",
                TopicName = "TestKafka.Topic"
            });
        }
    }
}
