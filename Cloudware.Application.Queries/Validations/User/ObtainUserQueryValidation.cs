using Cloudware.Application.Queries.User;
using FluentValidation;

namespace Cloudware.Application.Queries.Validations.User
{
    public class ObtainUserQueryValidation : AbstractValidator<ObtainUserQuery>
    {
        public ObtainUserQueryValidation()
        {
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("Informe o código do usuário.");
        }
    }
}
