using Cloudware.Application.Commands.Log;
using Cloudware.Application.Commands.Validations.Log;
using Cloudware.Core.Infra;
using Cloudware.Core.Infra.Enums;
using Cloudware.Core.Infra.Exceptions;
using Cludware.Repository.Entities;
using Cludware.Repository.Infra;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cloudware.Application.Commands
{
    public class LogCommandHandler :
        BaseHandler,
        IRequestHandler<CreateLogCommand, bool>,
        IRequestHandler<DeleteLogCommand, bool>
    {
        private readonly ILogger<LogCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public LogCommandHandler(ILogger<LogCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateLogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resultValidator = new CreateLogCommandValidation().Validate(request);

                if (resultValidator.IsValid)
                {
                    var entity = request.ToModelView<LogAuthenticationEntity, CreateLogCommand>();
                    var result = false;

                    switch (request.TypeLog)
                    {
                        case ETypeLog.Authentication:
                            result = await _unitOfWork.LogAuthenticationsRepository.AddAsync(entity);
                            break;
                        default:
                            throw new ApplicationException("Não foi possivel salvar o log, tipo de log nao definido.");
                    }

                    return result;
                }

                throw new EntityValidationException(resultValidator.Errors.FirstOrDefault().ErrorMessage);
            }
            catch (Exception ex)
            {
                throw ThrowException(ex, ETypeCommand.Create);
            }
        }

        public async  Task<bool> Handle(DeleteLogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resultValidator = new DeleteLogCommandValidation().Validate(request);

                if (resultValidator.IsValid)
                {
                    switch (request.TypeLog)
                    {
                        case ETypeLog.Authentication:
                            return await _unitOfWork.LogAuthenticationsRepository.DeleteAsync(request.LogId);
                        default:
                            throw new ApplicationException("Não foi possivel salvar o log, tipo de log nao definido.");
                    }
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
