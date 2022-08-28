using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestKafka.Infrastructure.DependencyInjection;

namespace TestKafka.Infrastructure
{
    public static class IoC
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddClients();
            services.AddConfigurations(configuration);
            services.AddMessageBuilders();
            services.AddServices();
        }
    }
}
