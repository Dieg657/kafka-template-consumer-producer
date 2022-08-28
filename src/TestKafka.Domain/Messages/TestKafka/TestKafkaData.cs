using Newtonsoft.Json;
using System;

namespace TestKafka.Domain.Messages.TestKafka
{
    public class TestKafkaData
    {
        public TestKafkaData()
        {
            PublishedTime = DateTime.Now;
        }

        [JsonProperty("publishedTime")]
        public DateTime PublishedTime { get; private set; }
    }
}
