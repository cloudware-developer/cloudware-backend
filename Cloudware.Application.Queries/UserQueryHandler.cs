using Cloudware.Application.Commands;
using Cloudware.Application.Infra;
using Cloudware.Application.Queries.User;
using Cloudware.Application.Queries.Validations.User;
using Cloudware.Core.Infra;
using Cloudware.Core.Infra.Enums;
using Cloudware.Core.Infra.Exceptions;
using Cludware.Repository.Entities;
using Cludware.Repository.Infra;
using Cludware.Repository.Infra.Cache;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cloudware.Application.Queries
{
    public class UserQueryHandler :
        BaseHandler,
        IRequestHandler<ObtainUserQuery, UserEntity>,
        IRequestHandler<ObtainUserByLoginQuery, UserEntity>,
        IRequestHandler<ObtainUserCollectionQuery, List<UserEntity>>
    {
        private readonly ILogger<UserCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheRepository _cacheRepository;
        private readonly IConfiguration _configuration;

        public UserQueryHandler(
            ILogger<UserCommandHandler> logger,
            IUnitOfWork unitOfWork,
            IConfiguration configuration,
            ICacheRepository cacheRepository
        )
        {
            _logger = logger;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _cacheRepository = cacheRepository;
        }

        public async Task<UserEntity> Handle(ObtainUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resultValidator = new ObtainUserQueryValidation().Validate(request);

                if (resultValidator.IsValid)
                {
                    var entity = await _unitOfWork.UsersRepository.GetByIdAsync(request.UserId);

                    if (entity == null)
                        throw new EntityValidationException("Usuário não encontrado.");

                    return entity;
                }

                throw new EntityValidationException(resultValidator.Errors.FirstOrDefault().ErrorMessage);
            }
            catch (Exception ex)
            {
                throw ThrowException(ex, ETypeCommand.ObtainItem);
            }
        }

        public async Task<List<UserEntity>> Handle(ObtainUserCollectionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resultValidator = new ObtainUserCollectionQueryValidation().Validate(request);

                if (resultValidator.IsValid)
                {
                    var filters = request.ToModelView<UserEntity, ObtainUserCollectionQuery>();
                    var collection = await _unitOfWork.UsersRepository.GetAllAsync(filters);

                    if (!collection.Any())
                        throw new EntityValidationException("Não foi encontrado nenhu registro.");

                    return collection;
                }

                throw new EntityValidationException(resultValidator.Errors.FirstOrDefault().ErrorMessage);
            }
            catch (Exception ex)
            {
                throw ThrowException(ex, ETypeCommand.ObtainCollection);
            }
        }

        public async Task<UserEntity> Handle(ObtainUserByLoginQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resultValidator = new ObtainUserByLoginQueryValidation().Validate(request);

                if (resultValidator.IsValid)
                {
                    var entity = await _unitOfWork.UsersRepository.GetByLoginAsync(request.Email, request.Password);

                    if (entity == null)
                        throw new EntityValidationException("Usuário não encontrado.");

                    var token = CreateAuthenticationTokenAsync(entity);
                    entity.Token = token;

                    await _unitOfWork.LogAuthenticationsRepository.AddAsync(new LogAuthenticationEntity(entity.UserId, entity.ToJson()));
                    await _cacheRepository.AddAsync($"{CacheKeys.TokenLogin}_{entity.UserId}", token);

                    entity.Password = string.Empty;
                    return entity;
                }

                throw new EntityValidationException(resultValidator.Errors.FirstOrDefault().ErrorMessage);
            }
            catch (Exception ex)
            {
                throw ThrowException(ex, ETypeCommand.ObtainCollection);
            }
        }

        private string CreateAuthenticationTokenAsync(UserEntity entity)
        {
            try
            {
                var secretKey = _configuration.GetSection("JwtConfig").GetValue<string>("Secret");
                var daysTokenExpiration = _configuration.GetSection("JwtConfig").GetValue<int>("DaysTokenExpiration");
                var symmetricSecurityKey = Encoding.ASCII.GetBytes(secretKey);
                var securityTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("GuidId", Guid.NewGuid().ToString()),
                        new Claim("UserId", entity.UserId.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddDays(daysTokenExpiration),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricSecurityKey), SecurityAlgorithms.HmacSha256Signature)
                };

                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
                var token = jwtSecurityTokenHandler.WriteToken(securityToken);

                return token;
            }
            catch (Exception ex)
            {
                throw ThrowException($"Erro ao gerar token de acesso.", ex);
            }
        }
    }
}
