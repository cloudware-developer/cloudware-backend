using Cloudware.Application.Commands.Company;
using FluentValidation;

namespace Cloudware.Application.Commands.Validations.Company
{
    public class DeleteCompanyCommandValidation : AbstractValidator<DeleteCompanyCommand>
    {
        public DeleteCompanyCommandValidation()
        {
            RuleFor(x => x.CompanyId).GreaterThan(0).WithMessage("Informe o código do usuário para poder atualiza-lo.");
        }
    }
}
