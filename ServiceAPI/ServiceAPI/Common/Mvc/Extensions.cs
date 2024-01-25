using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace ServiceAPI.Common.Mvc
{
    public static class Extensions
    {
        private static readonly string MyAllowSpecificOrigins = "OpsWebOrigins";
        public static IApplicationBuilder UseCorsStar(this IApplicationBuilder app)
        {
            app.UseCors(MyAllowSpecificOrigins);
            return app;
        }

        public static IServiceCollection AddCorsStar(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                                  builder1 =>
                                  {
                                      builder1.WithOrigins("*");
                                      builder1.AllowAnyHeader();
                                      builder1.AllowAnyMethod();
                                  });
            });
            return services;
        }

        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
            => builder.UseMiddleware<ErrorHandlerMiddleware>();
    }
}
