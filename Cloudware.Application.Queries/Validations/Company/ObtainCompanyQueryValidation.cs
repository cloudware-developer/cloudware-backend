using Cloudware.Application.Queries.Company;
using FluentValidation;

namespace Cloudware.Application.Queries.Validations.Company
{
    public class ObtainCompanyQueryValidation : AbstractValidator<ObtainCompanyQuery>
    {
        public ObtainCompanyQueryValidation()
        {
            RuleFor(x => x.CompanyId).GreaterThan(0).WithMessage("Informe o código do usuário.");
        }
    }
}
