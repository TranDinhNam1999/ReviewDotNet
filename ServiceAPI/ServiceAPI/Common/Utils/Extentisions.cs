namespace ServiceAPI.Common.Utils
{
    public static class Extentisions
    {
        public static IConfiguration GetIConfiguration(this IServiceCollection services)
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }
            return configuration!;
        }
    }
}
