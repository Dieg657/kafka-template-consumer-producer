namespace TestKafka.Kafka.Configs.Interfaces
{
    public interface IKafkaTopicConfig
    {
        public string TopicName { get; set; }
        public string Domain { get; set; }
        public string Action { get; set; }
    }
}
