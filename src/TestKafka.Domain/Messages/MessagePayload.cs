using Newtonsoft.Json;

namespace TestKafka.Domain.Messages
{
    public class MessagePayload<TData> : MessagePayloadBase
    {
        public MessagePayload(Meta meta, TData data) 
            : base(meta)
        {
            Data = data;
        }

        [JsonProperty("data")]
        public TData Data { get; set; }
    }
}
