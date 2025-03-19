using Pacagroup.Ecommerce.Services.WebApi.Modules.GlobalException;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder addMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
