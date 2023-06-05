using System;
using Test;
using TestKafka.Domain.Messages;

namespace TestKafka.Producer.Builders.Interfaces
{
    public interface IPayloadBuilder
    {
        MessagePayload<TData> BuildMessagePayload<TData>(TData data, Guid correlationId, string domain, string action);
        TestKafkaAvro BuildAvroMessage(Guid correlationId, string domain, string action);
    }
}
