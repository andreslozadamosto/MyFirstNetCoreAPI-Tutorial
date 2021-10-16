using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace MyFirstNetCoreWebAPI.WebAPI.Configuration
{
    public static class SwaggerStartupConfiguration
    {
        public static IServiceCollection AddStartupSwagger(this IServiceCollection services) 
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("MyFirstNetCoreRESTAPI-V1", new OpenApiInfo
                {
                    Title = "My First Net Core REST API",
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API by Andrés Lozada Mosto, You can find this tutorial here: https://dev.to/andreslozadamosto/creando-un-api-en-net-core-5-intro-2nc2",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Andres Lozada Mosto",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/andreslozadamosto"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT licence",
                        Url = new Uri("https://choosealicense.com/licenses/mit/"),
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IApplicationBuilder UseStartupSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/MyFirstNetCoreRESTAPI-V1/swagger.json", "MyFirstNetCoreRESTAPI v1");
                c.InjectStylesheet("/swagger-ui/swagger-custom.css");
            });
            return app;
        }
    }
}
