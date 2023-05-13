using Cloudware.Application.Commands;
using Cloudware.Application.Queries.Company;
using Cloudware.Application.Queries.Validations.Company;
using Cloudware.Core.Infra;
using Cloudware.Core.Infra.Enums;
using Cloudware.Core.Infra.Exceptions;
using Cludware.Repository.Entities;
using Cludware.Repository.Infra;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cloudware.Application.Queries
{
    public class CompanyQueryHandler :
        BaseHandler,
        IRequestHandler<ObtainCompanyQuery, CompanyEntity>,
        IRequestHandler<ObtainCompanyCollectionQuery, List<CompanyEntity>>
    {
        private readonly ILogger<CompanyCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyQueryHandler(ILogger<CompanyCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyEntity> Handle(ObtainCompanyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resultValidator = new ObtainCompanyQueryValidation().Validate(request);

                if (resultValidator.IsValid)
                {
                    var entity = await _unitOfWork.CompaniesRepository.GetByIdAsync(request.CompanyId);

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

        public async Task<List<CompanyEntity>> Handle(ObtainCompanyCollectionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resultValidator = new ObtainCompanyCollectionQueryValidation().Validate(request);

                if (resultValidator.IsValid)
                {
                    var filters = request.ToModelView<CompanyEntity, ObtainCompanyCollectionQuery>();
                    var collection = await _unitOfWork.CompaniesRepository.GetAllAsync(filters);

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
    }
}
