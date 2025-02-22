﻿

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Text.Json.Serialization;

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

            return services;
        }
    }
}
