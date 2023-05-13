using Cloudware.Api.Extensions;
using Cloudware.Core.Infra.Exceptions;

namespace Cloudware.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                services.AddControllers();

                services.AddCorsPolicy();

                services.AddSwaggerConfig();

                services.AddServices();

                services.AddJwtConfig(_configuration);

                services.AddAuthenticationCore();
            }
            catch (Exception ex)
            {
                throw new ApplicationErrorException($"Erro ao iniciar aplicação. Método {nameof(Startup)}.{nameof(ConfigureServices)}. {ex.Message}");
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            try
            {
                if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }

                app.UseHttpLogging();

                app.UseCorsPolicy();

                app.UseSwagger();

                app.UseRouting();

                //app.UseAuthentication();

                //app.UseAuthorization();

                //app.UseAuthorizationMiddleware();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers().RequireAuthorization();
                });
            }
            catch (Exception ex)
            {
                throw new ApplicationErrorException($"Erro ao iniciar aplicação. Método {nameof(Startup)}.{nameof(Configure)}. {ex.Message}");
            }
        }
    }
}
