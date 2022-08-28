using Newtonsoft.Json;
using System;

namespace TestKafka.Domain.Messages
{
    public class MessagePayloadBase
    {
        public MessagePayloadBase(Meta meta)
        {
            Meta = meta;
        }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }

    public class Meta
    {
        public Meta(InfoData infoData)
        {
            InfoData = infoData;
        }

        [JsonProperty("infoData")]
        public InfoData InfoData { get; set; }
    }

    public class InfoData
    {
        public InfoData(Guid correlationId, string domain, string action)
        {
            Id = Guid.NewGuid();
            CorrelationId = correlationId;
            Domain = domain;
            Action = action;
            Timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        [JsonProperty("id")]
        public Guid Id { get; set;  }
        [JsonProperty("correlationId")]
        public Guid CorrelationId { get; set; }
        [JsonProperty("domain")]
        public string Domain { get; set; }
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}