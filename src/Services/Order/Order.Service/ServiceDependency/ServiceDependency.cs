using EventBus.Messages.Common;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.DataAccess.DataAccessDependency;
using Order.Service.EventBusConsumer;
using Order.Service.IService;
using Order.Service.Service;

namespace Order.Service.ServiceDependency
{
    public static class ServiceDependency
    {
        public static void InjectServiceDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.InjectDataAccessDependenc(configuration);

            services.AddMassTransit(config =>
            {
                config.AddConsumer<BasketCheckoutConsumer>();

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration["EventBusSettings:HostAddress"]);
                    cfg.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, c =>
                    {
                        c.ConfigureConsumer<BasketCheckoutConsumer>(ctx);
                    });
                });
            });
            services.AddMassTransitHostedService();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
