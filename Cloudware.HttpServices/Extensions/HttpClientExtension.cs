using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace Cloudware.HttpServices.Extensions
{
    public static class HttpClientExtension
    {
        public static IServiceCollection AddInvestingHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            var baseAddress = configuration.GetSection("Clients").GetValue<string>("Investing");

            if (string.IsNullOrEmpty(baseAddress))
                throw new ArgumentException("A url base não foi informada para source Investing.");

            services.AddHttpClient<IInvestingHttpClient>()
                .ConfigureHttpClient(httpClient =>
                {
                    httpClient.BaseAddress = new Uri(baseAddress);
                    httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
                });

            return services;
        }

        public static IServiceCollection AddBancoCentralHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            var baseAddress = configuration.GetSection("Clients").GetValue<string>("BancoCentral");

            if (string.IsNullOrEmpty(baseAddress))
                throw new ArgumentException("A url base não foi informada para source Banco Central.");

            services.AddHttpClient<IInvestingHttpClient>()
                .ConfigureHttpClient(httpClient =>
                {
                    httpClient.BaseAddress = new Uri(baseAddress);
                    httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
                });

            return services;
        }

        public static IServiceCollection AddMelhorcambioHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            var baseAddress = configuration.GetSection("Clients").GetValue<string>("Melhorcambio");

            if (string.IsNullOrEmpty(baseAddress))
                throw new ArgumentException("A url base não foi informada para source Melhorcambio.com.");

            services.AddHttpClient<IInvestingHttpClient>()
                .ConfigureHttpClient(httpClient =>
                {
                    httpClient.BaseAddress = new Uri(baseAddress);
                    httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
                });

            return services;
        }
    }
}
