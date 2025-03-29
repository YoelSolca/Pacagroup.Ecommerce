using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Timeouts;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Feature
{
    public static class FeaturesExtensiones
    {

        public static IServiceCollection AddFeatures (this IServiceCollection services,  IConfiguration configuration)
        {
             string myPolicy = "policyApiEcommerce";    
           
            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(configuration["Config:OriginCors"])
                                                                                      .AllowAnyHeader()
                                                                                      .AllowAnyMethod()));
            services.AddMvc();

            services.AddControllers().AddJsonOptions(options =>
            {
                                                                 var enumConverter = new JsonStringEnumConverter();
                                                                 options.JsonSerializerOptions.Converters.Add(enumConverter);
            });

            services.AddRequestTimeouts(option =>
            {
                option.DefaultPolicy =
                new RequestTimeoutPolicy { Timeout = TimeSpan.FromMilliseconds(1500)};
                option.AddPolicy("CustomPolicy", TimeSpan.FromMilliseconds(2000));
        });


            return services;
        }
    }
}
