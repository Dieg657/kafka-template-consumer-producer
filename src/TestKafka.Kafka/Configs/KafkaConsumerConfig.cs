using TestKafka.Kafka.Configs.Interfaces;

namespace TestKafka.Kafka.Configs
{
    public class KafkaConsumerConfig : IKafkaConsumerConfig
    {
        public string BootstrapServers { get; set; }
        public string GroupId { get; set; }
    }
}
