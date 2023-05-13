using Cloudware.Application.Commands.User;
using FluentValidation;

namespace Cloudware.Application.Commands.Validations.User
{
    public class UpdateUserCommandValidation : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidation()
        {
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("Informe o código do usuário para poder atualiza-lo.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Informe o nome.").Length(3, 200).WithMessage("O nome deve ter no mínimo 3 e no máximo 200 caracteres.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Informe o email.").EmailAddress().WithMessage("Informe um email válido.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Informe um senha.").Length(5, 50).WithMessage("A senha deve ter no mínimo 6 e no máximo 20 caracteres.");
        }
    }
}
