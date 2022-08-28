using System;
using TestKafka.Domain.Messages;

namespace TestKafka.Producer.Builders.Message
{
    public static class MessagePayloadBuilder
    {
        public static MessagePayload<TData> BuildMessagePayload<TData>(TData data, Guid correlationId, string domain, string action)
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
    }
}
