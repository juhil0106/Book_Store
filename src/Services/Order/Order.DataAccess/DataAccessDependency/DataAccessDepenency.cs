using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.DataAccess.Context;
using Order.DataAccess.IRepository;
using Order.DataAccess.Repository;

namespace Order.DataAccess.DataAccessDependency
{
    public static class DataAccessDepenency
    {
        public static void InjectDataAccessDependenc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sql =>
                    {
                        sql.CommandTimeout(60);
                        sql.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                        sql.EnableRetryOnFailure();
                    });
            });

            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
