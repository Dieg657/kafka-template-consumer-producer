using System.Threading.Tasks;

namespace TestKafka.Consumer.Services.Interfaces
{
    internal interface IConsumerService
    {
        Task ConsumeMessage();
    }
}
