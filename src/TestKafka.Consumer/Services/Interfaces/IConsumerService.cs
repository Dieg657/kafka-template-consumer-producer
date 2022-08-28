using System.Threading.Tasks;

namespace TestKafka.Consumer.Services.Interfaces
{
    public interface IConsumerService
    {
        Task ConsumeMessageFromKafka();
    }
}
