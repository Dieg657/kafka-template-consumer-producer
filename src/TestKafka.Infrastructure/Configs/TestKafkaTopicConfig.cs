using TestKafka.Kafka.Configs.Interfaces;

namespace TestKafka.Infrastructure.Configs
{
    public class TestKafkaTopicConfig : IKafkaTopicConfig
    {
        public string TopicName { get; set; }
        public string Domain { get; set; }
        public string Action { get; set; }
    }
}
