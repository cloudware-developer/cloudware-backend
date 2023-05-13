namespace Cloudware.Api.Extensions
{
    public static class RedisCacheExtension
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = Configuration.GetConnectionString("RedisCache:ConnectionString");
            //    options.InstanceName = Configuration.GetValue<string>("RedisCache:InstanceName");
            //});

            return services;
        }
    }
}
