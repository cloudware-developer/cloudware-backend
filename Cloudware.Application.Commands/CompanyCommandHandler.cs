using Cloudware.Application.Commands.Company;
using Cloudware.Application.Commands.Validations.Company;
using Cloudware.Core.Infra;
using Cloudware.Core.Infra.Enums;
using Cloudware.Core.Infra.Exceptions;
using Cludware.Repository.Entities;
using Cludware.Repository.Infra;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cloudware.Application.Commands
{
    public class CompanyCommandHandler :
        BaseHandler,
        IRequestHandler<CreateCompanyCommand, bool>,
        IRequestHandler<UpdateCompanyCommand, bool>,
        IRequestHandler<DeleteCompanyCommand, bool>
    {
        private readonly ILogger<CompanyCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyCommandHandler(ILogger<CompanyCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resultValidator = new CreateCompanyCommandValidation().Validate(request);

                if (resultValidator.IsValid)
                {
                    var entity = request.ToModelView<CompanyEntity, CreateCompanyCommand>();
                    var result = await _unitOfWork.CompaniesRepository.AddAsync(entity);
                    return result;
                }

                throw new EntityValidationException(resultValidator.Errors.FirstOrDefault().ErrorMessage);
            }
            catch (Exception ex)
            {
                throw ThrowException(ex, ETypeCommand.Create);
            }
        }

        public async Task<bool> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resultValidator = new UpdateCompanyCommandValidation().Validate(request);

                if (resultValidator.IsValid)
                {
                    var entity = request.ToModelView<CompanyEntity, UpdateCompanyCommand>();
                    var result = await _unitOfWork.CompaniesRepository.UpdateAsync(entity);
                    return result;
                }

                throw new EntityValidationException(resultValidator.Errors.FirstOrDefault().ErrorMessage);
            }
            catch (Exception ex)
            {
                throw ThrowException(ex, ETypeCommand.Update);
            }
        }

        public async Task<bool> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resultValidator = new DeleteCompanyCommandValidation().Validate(request);

                if (resultValidator.IsValid)
                {
                    var entity = request.ToModelView<CompanyEntity, DeleteCompanyCommand>();
                    var result = await _unitOfWork.CompaniesRepository.UpdateAsync(entity);
                    return result;
                }

                throw new EntityValidationException(resultValidator.Errors.FirstOrDefault().ErrorMessage);
            }
            catch (Exception ex)
            {
                throw ThrowException(ex, ETypeCommand.Delete);
            }
        }
    }
}
