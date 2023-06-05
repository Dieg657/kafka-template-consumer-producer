using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestKafka.Infrastructure.Configs;
using TestKafka.Kafka.Builders;
using TestKafka.Kafka.Configs;
using TestKafka.Kafka.Handlers;
using TestKafka.Kafka.Handlers.Interfaces;

namespace TestKafka.Infrastructure.DependencyInjection
{
    public static class Modules
    {
        public static IServiceCollection AddClients(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<KafkaProducerConfig>(configuration.GetSection("Kafka:Producer"));
            services.Configure<KafkaConsumerConfig>(configuration.GetSection("Kafka:Consumer"));
            services.Configure<TestKafkaTopicConfig>(configuration.GetSection("Topics:Test"));

            return services;
        }

        public static IServiceCollection AddMessageBuilders(this IServiceCollection services)
        {
            services.AddScoped(typeof(IMessageBuilder<,>), typeof(MessageBuilder<,>));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IKafkaProducer<,>), typeof(KafkaProducer<,>));
            services.AddScoped(typeof(IKafkaConsumer<,>), typeof(KafkaConsumer<,>));

            return services;            
        }
    }
}
