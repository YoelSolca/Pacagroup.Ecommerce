using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Versioning
{
    public static class VersioningExtensions
    {
        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.ReportApiVersions = true;
                //o.ApiVersionReader = new QueryStringApiVersionReader("api-version");
                o.ApiVersionReader = new HeaderApiVersionReader("x-version");
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
            });

            return services;
        }
    }
}
