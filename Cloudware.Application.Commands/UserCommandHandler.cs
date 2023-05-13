using Cloudware.Application.Commands.User;
using Cloudware.Application.Commands.Validations.User;
using Cloudware.Core.Infra;
using Cloudware.Core.Infra.Enums;
using Cloudware.Core.Infra.Exceptions;
using Cludware.Repository.Entities;
using Cludware.Repository.Infra;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cloudware.Application.Commands
{
    public class UserCommandHandler :
        BaseHandler,
        IRequestHandler<CreateUserCommand, bool>,
        IRequestHandler<UpdateUserCommand, bool>,
        IRequestHandler<DeleteUserCommand, bool>,
        IRequestHandler<UpdateUserPasswordCommand, bool>
    {
        private readonly ILogger<UserCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UserCommandHandler(ILogger<UserCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resultValidator = new CreateUserCommandValidation().Validate(request);

                if (resultValidator.IsValid)
                {
                    var entity = request.ToModelView<UserEntity, CreateUserCommand>();
                    var result = await _unitOfWork.UsersRepository.AddAsync(entity);
                    return result;
                }

                throw new EntityValidationException(resultValidator.Errors.FirstOrDefault().ErrorMessage);
            }
            catch (Exception ex)
            {
                throw ThrowException(ex, ETypeCommand.Create);
            }
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resultValidator = new UpdateUserCommandValidation().Validate(request);

                if (resultValidator.IsValid)
                {
                    var entity = request.ToModelView<UserEntity, UpdateUserCommand>();
                    var result = await _unitOfWork.UsersRepository.UpdateAsync(entity);
                    return result;
                }

                throw new EntityValidationException(resultValidator.Errors.FirstOrDefault().ErrorMessage);
            }
            catch (Exception ex)
            {
                throw ThrowException(ex, ETypeCommand.Update);
            }
        }

        public async Task<bool> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resultValidator = new UpdateUserPasswordCommandValidation().Validate(request);

                if (resultValidator.IsValid)
                {
                    var entity = request.ToModelView<UserEntity, UpdateUserPasswordCommand>();
                    var result = await _unitOfWork.UsersRepository.UpdatePasswordAsync(entity);
                    return result;
                }

                throw new EntityValidationException(resultValidator.Errors.FirstOrDefault().ErrorMessage);
            }
            catch (Exception ex)
            {
                throw ThrowException(ex, ETypeCommand.Update);
            }
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resultValidator = new DeleteUserCommandValidation().Validate(request);

                if (resultValidator.IsValid)
                {
                    var entity = request.ToModelView<UserEntity, DeleteUserCommand>();
                    var result = await _unitOfWork.UsersRepository.UpdateAsync(entity);
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
