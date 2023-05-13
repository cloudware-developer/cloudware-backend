using Cloudware.Application.Queries.User;
using FluentValidation;

namespace Cloudware.Application.Queries.Validations.User
{
    public class ObtainUserByLoginQueryValidation : AbstractValidator<ObtainUserByLoginQuery>
    {
        public ObtainUserByLoginQueryValidation()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Informe o email.").EmailAddress().WithMessage("Informe um email válido.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Informe um senha.").Length(5, 20).WithMessage("A senha deve ter no mínimo 6 e no máximo 20 caracteres.");
        }
    }
}
