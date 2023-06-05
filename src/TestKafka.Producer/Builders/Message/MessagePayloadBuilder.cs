using System;
using Test;
using TestKafka.Domain.Messages;
using TestKafka.Producer.Builders.Interfaces;

namespace TestKafka.Producer.Builders.Message
{
    public class MessagePayloadBuilder : IPayloadBuilder
    {
        public MessagePayload<TData> BuildMessagePayload<TData>(TData data, Guid correlationId, string domain, string action)
        {
            return new MessagePayload<TData>(BuildMeta(correlationId, domain, action), data);
        }

        private static Meta BuildMeta(Guid correlationId, string domain, string action)
        {
            return new Meta(BuildInfoData(correlationId, domain, action));
        }

        private static InfoData BuildInfoData(Guid correlationId, string domain, string action)
        {
            return new InfoData(correlationId, domain, action);
        }

        public TestKafkaAvro BuildAvroMessage(Guid correlationId, string domain, string action)
        {
            return new TestKafkaAvro
            {
                data = new data { publishedTime = DateTime.Now.ToString() },
                meta = new meta { infoData = new infoData { action = action, correlationId = correlationId.ToString(), domain = domain, id = Guid.NewGuid().ToString(), timestamp = (int)DateTimeOffset.Now.ToUnixTimeSeconds() } }
            };
        }
    }
}
