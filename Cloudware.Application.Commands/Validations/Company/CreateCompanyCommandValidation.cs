using Cloudware.Application.Commands.Company;
using FluentValidation;

namespace Cloudware.Application.Commands.Validations.Company
{
    public class CreateCompanyCommandValidation : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Informe o nome.").Length(3, 200).WithMessage("O nome deve ter no mínimo 3 e no máximo 200 caracteres.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Informe o email.").EmailAddress().WithMessage("Informe um email válido.");
        }
    }
}
