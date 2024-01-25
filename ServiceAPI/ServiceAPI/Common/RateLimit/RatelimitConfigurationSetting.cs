namespace ServiceAPI.Common.Ratelimit
{
    public class RatelimitConfigurationSetting
    {
        public string MyRateLimit = "CommonRateLimit";
        public int PermitLimit { get; set; } = 100;
        public int Window { get; set; } = 10;
        public int ReplenishmentPeriod { get; set; } = 2;
        public int QueueLimit { get; set; } = 2;
        public int SegmentsPerWindow { get; set; } = 8;
        public int TokenLimit { get; set; } = 10;
        public int TokenLimit2 { get; set; } = 20;
        public int TokensPerPeriod { get; set; } = 4;
        public bool AutoReplenishment { get; set; } = false;

        public RatelimitConfigurationSetting(IConfiguration configuration)
        {
            this.MyRateLimit = configuration.GetSection("RateLimitSettings").GetValue<string>("MyRateLimit")!;
            this.PermitLimit = configuration.GetSection("RateLimitSettings").GetValue<int>("PermitLimit");
            this.Window = configuration.GetSection("RateLimitSettings").GetValue<int>("Window");
            this.ReplenishmentPeriod = configuration.GetSection("RateLimitSettings").GetValue<int>("ReplenishmentPeriod");
            this.QueueLimit = configuration.GetSection("RateLimitSettings").GetValue<int>("QueueLimit");
            this.SegmentsPerWindow = configuration.GetSection("RateLimitSettings").GetValue<int>("SegmentsPerWindow");
            this.TokenLimit = configuration.GetSection("RateLimitSettings").GetValue<int>("TokenLimit");
            this.TokenLimit2 = configuration.GetSection("RateLimitSettings").GetValue<int>("TokenLimit2");
            this.TokensPerPeriod = configuration.GetSection("RateLimitSettings").GetValue<int>("TokensPerPeriod");
            this.AutoReplenishment = configuration.GetSection("RateLimitSettings").GetValue<bool>("AutoReplenishment");
        }
    }
}
