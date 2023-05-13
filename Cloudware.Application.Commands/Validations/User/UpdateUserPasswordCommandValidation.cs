using Cloudware.Application.Commands.User;
using FluentValidation;

namespace Cloudware.Application.Commands.Validations.User
{
    public class UpdateUserPasswordCommandValidation : AbstractValidator<UpdateUserPasswordCommand>
    {
        public UpdateUserPasswordCommandValidation()
        {
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("Informe o código do usuário.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Informe uma senha.").Length(8, 20).WithMessage("A senha deve ser de no mínimo 8 e no máximo 20 caracteres.");
        }
    }
}
