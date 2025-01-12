using Microsoft.Extensions.DependencyInjection;
using Pacagroup.Ecommerce.Application.Validator;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Validator
{
    public static class ValidatorExtensiones
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            //Se crea una nueva instancia de la clase UsersDtoValidator por cada petición
            services.AddTransient <UsersDtoValidator>();
            return services;
        }
    }
}
