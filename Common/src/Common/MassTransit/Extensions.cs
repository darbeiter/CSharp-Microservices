using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using Common.Settings;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Common.MassTransit
{
    public static class Extensions
    {
        public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services)
        {
            services.AddMassTransit(configure => {
                configure.AddConsumers(Assembly.GetEntryAssembly());

            configure.UsingRabbitMq((context, configurator) => {
                var configuration = context.GetService<IConfiguration>();
                var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
                var rabbitMQSettings = configuration.GetSection(nameof(RabbitMQSettings)).Get<RabbitMQSettings>();
                configurator.Host(rabbitMQSettings.Host);
                configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(serviceSettings.ServiceName, false));
            }); 
        });

            services.Configure<MassTransitHostOptions>(options =>
            {
                options.WaitUntilStarted = true;
                options.StartTimeout = TimeSpan.FromSeconds(30);
                options.StopTimeout = TimeSpan.FromMinutes(1);
            });

            return services;
        }
    }
}