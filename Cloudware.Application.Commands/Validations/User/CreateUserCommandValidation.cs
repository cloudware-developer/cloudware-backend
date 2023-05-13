using Cloudware.Application.Commands.User;
using FluentValidation;

namespace Cloudware.Application.Commands.Validations.User
{
    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Informe o nome.").Length(3, 200).WithMessage("O nome deve ter no mínimo 3 e no máximo 200 caracteres.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Informe o email.").EmailAddress().WithMessage("Informe um email válido.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Informe um senha.").Length(5, 20).WithMessage("A senha deve ter no mínimo 6 e no máximo 20 caracteres.");
        }
    }
}
