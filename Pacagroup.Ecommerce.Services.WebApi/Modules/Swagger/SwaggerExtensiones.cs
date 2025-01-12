using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Collections.Generic;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Swagger
{
    public static class SwaggerExtensiones
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Pacagroup Technology Services API Market",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://pacagroup.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Alex Espejo",
                        Email = "alex.espejo.c@gmail.com",
                        Url = new Uri("https://pacagroup.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://pacagroup.com/licence")
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                var security = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter JWT Bearer authorization token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(security.Reference.Id, security);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {security, new List<string>() }
                });

            });

            return services;
        }
    }
}
