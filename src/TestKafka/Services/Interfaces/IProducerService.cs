using System.Threading.Tasks;

namespace TestKafka.Producer.Services.Interfaces
{
    internal interface IProducerService
    {
        Task ProduceMessageToKafka();
    }
}
