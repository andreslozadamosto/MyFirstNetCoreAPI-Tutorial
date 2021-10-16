using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyFirstNetCoreWebAPI.WebAPI.Configuration
{
    public static class RateLimitStartupConfiguration
    {
        public static IServiceCollection AddStartupRateLimit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));

            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            return services;
        }

        public static IApplicationBuilder UseStartupRateLimit(this IApplicationBuilder app)
        {
            app.UseIpRateLimiting();

            return app;
        }
    }
}
