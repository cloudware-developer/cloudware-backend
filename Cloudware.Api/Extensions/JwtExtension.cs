using Cloudware.Core.Infra.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Cloudware.Api.Extensions
{
    public static class JwtExtension
    {
        public static IServiceCollection AddJwtConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var secretKey = configuration.GetSection("JwtConfig").GetValue<string>("Secret");

            if (string.IsNullOrEmpty(secretKey))
                throw new ApplicationErrorException($"Tag 'Secret' dentro da section JwtConfig não informada no arquivo appsettings.{environment}.json. Método {nameof(JwtExtension)}.{nameof(AddJwtConfig)}.");

            var symmetricSecurityKey = Encoding.ASCII.GetBytes(secretKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricSecurityKey),
                };
            });

            return services;
        }
    }
}
