using Cloudware.Application.Commands.User;
using FluentValidation;

namespace Cloudware.Application.Commands.Validations.User
{
    public class DeleteUserCommandValidation : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidation()
        {
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("Informe o código do usuário para poder atualiza-lo.");
        }
    }
}
