using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestKafka.Consumer.Services.Interfaces;

namespace TestKafka.Consumer
{
    internal class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConsumerService _consumeService;

        public Worker(ILogger<Worker> logger, IConsumerService consumeService)
        {
            _logger = logger;
            _consumeService = consumeService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Consume Worker started at: {DateTime.Now}");

            while(!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Start consuming message at {DateTime.Now}...");
                await _consumeService.ConsumeMessageFromKafka();
            }

            _logger.LogInformation($"Consumer Worker stoppet at: {DateTime.Now}");
        }
    }
}
