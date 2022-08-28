namespace TestKafka.Kafka.Configs.Interfaces
{
    public interface IKafkaConsumerConfig
    {
        public string BootstrapServers { get; set; }
        public string GroupId { get; set; }
    }
}
