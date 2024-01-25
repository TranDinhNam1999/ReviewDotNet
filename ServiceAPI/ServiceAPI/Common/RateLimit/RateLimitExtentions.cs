using Microsoft.AspNetCore.RateLimiting;
using ServiceAPI.Common.Utils;
using System.Threading.RateLimiting;

namespace ServiceAPI.Common.Ratelimit
{
    public static class RateLimitExtentions
    {
        public static IServiceCollection AddRateLimit(this IServiceCollection services)
        {
            IConfiguration configuration = services.GetIConfiguration();
            var rateLimitSetting = configuration.GetRateLimitConfigurationSetting();

            services.AddRateLimiter(_ => _
            .AddFixedWindowLimiter(policyName: "fixed", options =>
            {
                options.PermitLimit = rateLimitSetting.PermitLimit;
                options.Window = TimeSpan.FromSeconds(rateLimitSetting.Window);
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.QueueLimit = rateLimitSetting.QueueLimit;
            }));

            return services;
        }

        public static RatelimitConfigurationSetting GetRateLimitConfigurationSetting(this IConfiguration configuration)
        {
            return new RatelimitConfigurationSetting(configuration);
        }
    }
}
