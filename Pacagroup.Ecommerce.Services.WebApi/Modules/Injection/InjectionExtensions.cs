using Pacagroup.Ecommerce.Application.Interface.Presentation;
using Pacagroup.Ecommerce.Services.WebApi.Modules.GlobalException;
using Pacagroup.Ecommerce.Services.WebApi.Services;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddTransient<GlobalExceptionHandler>();
            services.AddScoped<ICurrentUser, CurrentUser>();

            return services;
        }
    }
}
