using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using TestKafka.Infrastructure;
using TestKafka.Producer.Services;
using TestKafka.Producer.Services.Interfaces;

namespace TestKafka.Producer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    var configuration = GetConfiguration();
                    services.AddSingleton<IConfiguration>(_ => configuration);
                    services.RegisterServices(hostContext.Configuration);
                    services.AddScoped<IProducerService, ProducerService>();
                    services.AddHostedService<Worker>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                });

        private static IConfigurationRoot GetConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);

            return configurationBuilder.Build();
        }
    }
}
