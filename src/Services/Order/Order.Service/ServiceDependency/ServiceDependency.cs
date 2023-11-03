using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.DataAccess.DataAccessDependency;
using Order.Service.IService;
using Order.Service.Service;

namespace Order.Service.ServiceDependency
{
    public static class ServiceDependency
    {
        public static void InjectServiceDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.InjectDataAccessDependenc(configuration);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
