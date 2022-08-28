using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestKafka.Domain.Messages;
using TestKafka.Domain.Messages.TestKafka;
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
            services.AddScoped<IMessageBuilder<string, MessagePayload<TestKafkaData>>, MessageBuilder<string, MessagePayload<TestKafkaData>>>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IKafkaProducer<string, MessagePayload<TestKafkaData>>, KafkaProducer<string, MessagePayload<TestKafkaData>>>();
            services.AddScoped<IKafkaConsumer<string, MessagePayload<TestKafkaData>>, KafkaConsumer<string, MessagePayload<TestKafkaData>>>();

            return services;            
        }
    }
}
