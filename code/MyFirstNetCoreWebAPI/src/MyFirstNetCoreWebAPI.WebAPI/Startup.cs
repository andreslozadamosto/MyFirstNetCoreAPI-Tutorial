using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyFirstNetCoreWebAPI.WebAPI.Data.Interfaces;
using MyFirstNetCoreWebAPI.WebAPI.Data.Repositories;
using System;
using System.IO;
using System.Reflection;

namespace MyFirstNetCoreWebAPI.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "My First Net Core REST API",
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API by Andr�s Lozada Mosto, You can find this tutorial here: https://dev.to/andreslozadamosto/creando-un-api-en-net-core-5-intro-2nc2",
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


            services.AddSingleton<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStaticFiles();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyFirstNetCoreWebAPI.WebAPI v1");
                    c.InjectStylesheet("/swagger-ui/swagger-custom.css");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
