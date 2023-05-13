namespace Cloudware.Api.Extensions
{
    public static class CorsExtension
    {
        private const string _corsPolicyName = "AllowAll";

        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            return services.AddCors(options =>
            {
                options.AddPolicy(_corsPolicyName,
                    builder => builder
                        .WithOrigins(
                            "http://localhost:4200", "http://localhost:4444")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithExposedHeaders("x-custom-header")
                );
            });
        }

        public static IServiceCollection AddCorsPolicy(this IServiceCollection services, List<string> origins)
        {
            return services.AddCors(options =>
            {
                options.AddPolicy(_corsPolicyName,
                    builder => builder
                        .WithOrigins(origins.ToArray())
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithExposedHeaders("x-custom-header")
                );
            });
        }

        public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app)
        {
            // return app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            return app.UseCors(_corsPolicyName);
        }
    }
}
