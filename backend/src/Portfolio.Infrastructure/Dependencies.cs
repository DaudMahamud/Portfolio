using Microsoft.Extensions.DependencyInjection;
using Portfolio.Infrastructure.Persistence;
using Portfolio.Application.Interfaces.Common;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Infrastructure
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.RegisterPersistence(connectionString);

            return services;
        }

        private static IServiceCollection RegisterPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDBContext>(builder =>
            {
                builder.UseNpgsql(connectionString, options =>
                {
                    options.MigrationsHistoryTable("Migrations");
                });
            });

            services.AddScoped<IApplicationDBContext>(provider =>
            provider.GetRequiredService<ApplicationDBContext>());

            return services;
        }
    }
}
