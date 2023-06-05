using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using TestKafka.Producer.Services.Interfaces;

namespace TestKafka.Producer
{
    [ExcludeFromCodeCoverage]
    internal class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IProducerAvroService _producerService;

        public Worker(ILogger<Worker> logger,
                      IProducerAvroService activeAccountService)
        {
            _logger = logger;
            _producerService = activeAccountService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Producer Worker started at: {DateTime.Now}");
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Worker now will try to send message at {DateTime.Now}...");

                await _producerService.ProduceMessage();
                
                await Task.Delay(1000);
            }
            _logger.LogInformation($"Producer Worker stoppet at: {DateTime.Now}");
        }
    }
}
