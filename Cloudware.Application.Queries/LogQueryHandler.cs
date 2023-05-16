using Cloudware.Application.Commands;
using Cloudware.Application.Queries.Log;
using Cloudware.Application.Queries.Validations.Log;
using Cloudware.Core.Infra;
using Cloudware.Core.Infra.Enums;
using Cloudware.Core.Infra.Exceptions;
using Cludware.Repository.Entities;
using Cludware.Repository.Infra;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cloudware.Application.Queries
{
    public class LogQueryHandler :
        BaseHandler,
        IRequestHandler<ObtainLogQuery, LogAuthenticationEntity>,
        IRequestHandler<ObtainLogCollectionQuery, List<LogAuthenticationEntity>>
    {
        private readonly ILogger<LogCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public LogQueryHandler(
            ILogger<LogCommandHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<LogAuthenticationEntity?> Handle(ObtainLogQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resultValidator = new ObtainLogQueryValidation().Validate(request);

                if (resultValidator.IsValid)
                {
                    switch ((ETypeLog)request.TypeLog)
                    {
                        case ETypeLog.Authentication:
                            return await _unitOfWork.LogAuthenticationsRepository.GetByIdAsync(request.LogId);
                        default:
                            throw new ApplicationException("Não foi possivel encontrar o log informado.");
                    }
                }

                throw new EntityValidationException(resultValidator.Errors.FirstOrDefault().ErrorMessage);
            }
            catch (Exception ex)
            {
                throw ThrowException(ex, ETypeCommand.ObtainCollection);
            }
        }

        public async Task<List<LogAuthenticationEntity>> Handle(ObtainLogCollectionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resultValidator = new ObtainLogCollectionQueryValidation().Validate(request);

                if (resultValidator.IsValid)
                {
                    var filters = request.ToModelView<LogAuthenticationEntity, ObtainLogCollectionQuery>();

                    switch (request.TypeLog)
                    {
                        case ETypeLog.Authentication:
                        {
                            var collection = (await _unitOfWork.LogAuthenticationsRepository.GetAllAsync(filters)).ToList();
                            if (!collection.Any()) throw new EntityValidationException("Não foi encontrado nenhu registro.");
                            return collection;
                        }
                        default:
                            throw new ApplicationException("Não foi possivel encontrar os logs, tipo de log nao definido.");
                    }

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
