using TestKafka.Kafka.Configs.Interfaces;

namespace TestKafka.Kafka.Configs
{
    public class KafkaProducerConfig : IKafkaProducerConfig
    {
        public string BootstrapServers { get; set; }
    }
}
