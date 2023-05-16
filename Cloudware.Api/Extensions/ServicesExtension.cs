using Cloudware.Application.Commands;
using Cloudware.Application.Commands.Company;
using Cloudware.Application.Commands.Log;
using Cloudware.Application.Commands.User;
using Cloudware.Application.Queries;
using Cloudware.Application.Queries.Company;
using Cloudware.Application.Queries.Log;
using Cloudware.Application.Queries.User;
using Cludware.Repository;
using Cludware.Repository.Entities;
using Cludware.Repository.Infra;
using Cludware.Repository.Infra.Cache;
using MediatR;
using System.Reflection;
using Cloudware.HttpServices.Extensions;

namespace Cloudware.Api.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICacheRepository, CacheRepository>();
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //----------------------------------------------------
            // CQRS - Commands
            //----------------------------------------------------

            // User
            services.AddScoped<IRequestHandler<CreateUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserPasswordCommand, bool>, UserCommandHandler>();

            // Company
            services.AddScoped<IRequestHandler<CreateCompanyCommand, bool>, CompanyCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCompanyCommand, bool>, CompanyCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteCompanyCommand, bool>, CompanyCommandHandler>();

            // Log
            services.AddScoped<IRequestHandler<CreateLogCommand, bool>, LogCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteLogCommand, bool>, LogCommandHandler>();

            //----------------------------------------------------
            // CQRS - Queries
            //----------------------------------------------------

            // User
            services.AddScoped<IRequestHandler<ObtainUserQuery, UserEntity>, UserQueryHandler>();
            services.AddScoped<IRequestHandler<ObtainUserCollectionQuery, List<UserEntity>>, UserQueryHandler>();
            services.AddScoped<IRequestHandler<ObtainUserByLoginQuery, UserEntity>, UserQueryHandler>();

            // Company
            services.AddScoped<IRequestHandler<ObtainCompanyQuery, CompanyEntity>, CompanyQueryHandler>();
            services.AddScoped<IRequestHandler<ObtainCompanyCollectionQuery, List<CompanyEntity>>, CompanyQueryHandler>();

            // Log
            services.AddScoped<IRequestHandler<ObtainLogQuery, LogAuthenticationEntity>, LogQueryHandler>();
            services.AddScoped<IRequestHandler<ObtainLogCollectionQuery, List<LogAuthenticationEntity>>, LogQueryHandler>();

            //----------------------------------------------------
            // CQRS - Repositories
            //----------------------------------------------------
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ILogAuthenticationRepository, LogAuthenticationRepository>();

            //----------------------------------------------------
            // External Services Retrieve Data.
            //----------------------------------------------------
            services.AddInvestingHttpClient(configuration);
            services.AddBancoCentralHttpClient(configuration);

            return services;
        }
    }
}
