using Microsoft.AspNetCore.RateLimiting;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.RateLimiter
{
    public static class RateLimiterExtension
    {
        public static IServiceCollection AddRateLimiting(this IServiceCollection services, IConfiguration configuration)
        {
            var fixedWindowPolicy = "fixedWindow";

            services.AddRateLimiter(configurationOptions =>
            {
                configurationOptions.AddFixedWindowLimiter(policyName: fixedWindowPolicy, fixedWindow =>
                {
                    fixedWindow.PermitLimit = int.Parse(configuration["RateLimit:PermitLimit"]);
                    fixedWindow.Window = TimeSpan.FromSeconds(int.Parse(configuration["RateLimit:Window"]));
                    fixedWindow.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                    fixedWindow.QueueLimit = int.Parse(configuration["RateLimit:QueueLimit"]);
                });

                configurationOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            });


            return services;
        }
    }
}
