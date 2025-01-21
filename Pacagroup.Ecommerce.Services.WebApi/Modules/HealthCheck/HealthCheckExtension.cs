namespace Pacagroup.Ecommerce.Services.WebApi.Modules.HealthCheck
{
    public static class HealthCheckExtension
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("NorthwindConnection"), tags: new[] { "database" })
                .AddRedis(configuration.GetConnectionString("RedisConnection"), tags: new[] { "cache" })
                .AddCheck<HealthCheckCustom>("HealthCheckCustom", tags: new[] { "custom" });

            services.AddHealthChecksUI().AddInMemoryStorage();

            return services;
        }
    }
}
